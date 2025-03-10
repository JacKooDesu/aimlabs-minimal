using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using Unity.Mathematics;

namespace ALM.Screens.Mission
{

    using System.Linq;
    using ALM.Screens.Base;
    using Base.Setting;
    using Data;

    using TickGroup = Common.TickableGroup<Base.TickTiming.ManagedRender>;

    public class BallPoolService : IDisposable
    {
        readonly TickGroup _tickGroup;
        readonly AudioService _audioService;
        readonly ObjectSetting _objectSetting;
        readonly AudioSetting _audioSetting;

        public ObjectPool<Ball> Pool { get; private set; }
        public Func<Ball> BallFactory;
        Ball _BallFactory()
        {
            var ball = GameObject
                .CreatePrimitive(PrimitiveType.Sphere);
            ball.GetComponent<MeshRenderer>().material = _material;
            var component = ball.AddComponent<Ball>();

            return component;
        }
        /// <summary>
        /// All balls in pool
        /// </summary>
        List<Ball> _balls = new List<Ball>();

        readonly Material _material;

        public event Action<Ball> OnBallHit;
        AudioClip _hitSound;

        public BallPoolService(
            TickGroup tickGroup,
            MissionScoreData missionScoreData,
            ObjectSetting objectSetting,
            AudioService audioService,
            AudioSetting audioSetting,
            MissionLoader.PlayableMission mission)
        {
            _tickGroup = tickGroup;
            _audioService = audioService;
            _objectSetting = objectSetting;
            _audioSetting = audioSetting;

            audioSetting.GetAudioClipSync(
                Constants.Audio.HIT_SOUND,
                clip => _hitSound = clip);

            Pool = new ObjectPool<Ball>(
                () => CreateBall(mission),
                GetBall,
                ReleaseBall,
                DestroyBall);

            _material = RuntimeResources.DefaultLitMaterial;

            _objectSetting.OnChange += UpdateBallColor;
            _audioSetting.OnChange += OnAudioChange;
        }

        void OnAudioChange(string path)
        {
            if (path != AudioSetting.GetAudioClipPath(Constants.Audio.HIT_SOUND))
                return;

            _audioSetting.GetAudioClipSync(
                Constants.Audio.HIT_SOUND,
                clip => _hitSound = clip);

            // TODO: Tracking type is not handlable
            // _balls.ForEach(b =>{})
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
            MissionLoader.PlayableMission mission)
        {
            var ball = (BallFactory ??= _BallFactory).Invoke();

            ball.OnHit += () => OnBallHit?.Invoke(ball);
            if (mission.Outline.Type is Data.MissionOutline.MissionType.Tracking)
            {
                var s = _audioService.BindTo(ball.transform);
                s.clip = _hitSound;
                ball.OnHit += () =>
                {
                    s.pitch = math.lerp(1.5f, 1f, ball.Hp);
                    s.Play();
                };
            }
            else
                ball.OnHit += () =>
                    _audioService.PlaySoundAtPos(
                        _hitSound,
                        ball.transform.position);

            _balls.Add(ball);

            return ball;
        }

        void GetBall(Ball ball)
        {
            _tickGroup.Reg(ball);

            ball.gameObject.SetActive(true);
        }
        void ReleaseBall(Ball ball)
        {
            _tickGroup.Unreg(ball);
            ball.gameObject.SetActive(false);
        }
        void DestroyBall(Ball ball)
        {
            _tickGroup.Unreg(ball);

            _balls.Add(ball);
        }

        public Ball Ball(int typeIndex = 0)
        {
            var ball = Pool.Get();
            ball.Color = _objectSetting.GetBallColor(typeIndex);
            ball.TypeIndex = typeIndex;
            return ball;
        }

        public Ball[] GetBalls(int count, int type = 0) =>
            Enumerable.Repeat(Ball(type), count).ToArray();

        public void Release(Ball ball) => Pool.Release(ball);

        public void Dispose()
        {
            _objectSetting.OnChange -= UpdateBallColor;
            _audioSetting.OnChange -= OnAudioChange;
        }
    }
}
