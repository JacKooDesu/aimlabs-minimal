using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using Unity.Mathematics;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    using Base.Setting;

    public class BallPoolService : IDisposable
    {
        readonly MissionLifetimeScope _scope;
        readonly AudioService _audioService;
        readonly ObjectSetting _objectSetting;
        public ObjectPool<Ball> Pool { get; private set; }
        /// <summary>
        /// All balls in pool
        /// </summary>
        List<Ball> _balls = new List<Ball>();

        readonly Material _material;

        public event Action<Ball> OnBallHit;
        AudioClip _hitSound;

        public BallPoolService(
            MissionLifetimeScope scope,
            MissionScoreData missionScoreData,
            ObjectSetting objectSetting,
            AudioService audioService,
            AudioSetting audioSetting,
            MissionLoader.PlayableMission mission)
        {
            _scope = scope;
            _audioService = audioService;
            _objectSetting = objectSetting;

            audioSetting.GetAudioClipSync(
                Constants.Audio.HIT_SOUND,
                clip => _hitSound = clip);

            Pool = new ObjectPool<Ball>(
                () => CreateBall(missionScoreData, mission),
                GetBall,
                ReleaseBall,
                DestroyBall);

            _material = new Material(Shader.Find("Universal Render Pipeline/Lit"));

            _objectSetting.OnChange += UpdateBallColor;
        }

        void UpdateBallColor(string path)
        {
            _balls.ForEach(b =>
            {
                if (path == _objectSetting.GetBallColorPath(b.TypeIndex))
                    b.Color = _objectSetting.GetBallColor(b.TypeIndex);
            });
        }

        Ball CreateBall(
            MissionScoreData scoreData,
            MissionLoader.PlayableMission mission)
        {
            var ball = GameObject
                .CreatePrimitive(PrimitiveType.Sphere);
            ball.GetComponent<MeshRenderer>().material = _material;
            var component = ball.AddComponent<Ball>();
            component.OnHit += () => OnBallHit?.Invoke(component);
            if (mission.Outline.Type is Data.MissionOutline.MissionType.Tracking)
            {
                var s = _audioService.BindTo(ball.transform);
                s.clip = _hitSound;
                component.OnHit += () =>
                {
                    s.pitch = math.lerp(1.5f, 1f, component.Hp);
                    s.Play();
                };
            }
            else
                component.OnHit += () =>
                    _audioService.PlaySoundAtPos(
                        _hitSound,
                        ball.transform.position);

            _balls.Add(component);

            return component;
        }

        void GetBall(Ball ball)
        {
            var entry = _scope.Container.Resolve<MissionEntry>();
            entry.RegTickable(ball);
        }
        void ReleaseBall(Ball ball)
        {
            var entry = _scope.Container.Resolve<MissionEntry>();
            entry.UnregTickable(ball);
        }
        void DestroyBall(Ball ball)
        {
            var entry = _scope.Container.Resolve<MissionEntry>();
            entry.UnregTickable(ball);

            _balls.Add(ball);
        }

        public Ball Ball(int typeIndex = 0)
        {
            var ball = Pool.Get();
            ball.Color = _objectSetting.GetBallColor(typeIndex);
            ball.TypeIndex = typeIndex;
            return ball;
        }

        public Ball[] GetBalls(int count, int type = 0)
        {
            var balls = new Ball[count];
            for (var i = 0; i < count; i++)
                balls[i] = Ball(type);

            return balls;
        }

        public void Dispose()
        {
            _objectSetting.OnChange -= UpdateBallColor;
        }
    }
}
