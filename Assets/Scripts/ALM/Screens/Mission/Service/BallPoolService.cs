using System;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base;
    using Base.Setting;

    public class BallPoolService
    {
        readonly MissionLifetimeScope _scope;
        readonly AudioService _audioService;
        readonly ObjectSetting _objectSetting;
        readonly AudioClip _hitSound;
        public ObjectPool<Ball> Pool { get; private set; }

        readonly Material _material;

        public event Action<Ball> OnBallHit;

        public BallPoolService(
            MissionLifetimeScope scope,
            MissionScoreData missionScoreData,
            ObjectSetting objectSetting,
            AudioService audioService,
            MissionLoader.PlayableMission mission)
        {
            _scope = scope;
            _audioService = audioService;
            _objectSetting = objectSetting;

            _hitSound = Resources.Load<AudioClip>("Audio/dot");

            Pool = new ObjectPool<Ball>(
                () => CreateBall(missionScoreData, mission),
                GetBall,
                ReleaseBall,
                DestroyBall);

            _material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        }

        Ball CreateBall(
            MissionScoreData scoreData,
            MissionLoader.PlayableMission mission)
        {
            var ball = GameObject
                .CreatePrimitive(PrimitiveType.Sphere);
            ball.GetComponent<MeshRenderer>().material = _material;
            var component  = ball.AddComponent<Ball>();
            component.OnHit += () => OnBallHit?.Invoke(component);
            component.OnHit += () =>
                _audioService.PlaySoundAtPos(
                    _hitSound,
                    ball.transform.position);
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
        }

        public Ball Ball(int typeIndex = 0)
        {
            var ball = Pool.Get();
            ball.Color = _objectSetting.GetBallColor(typeIndex);
            return ball;
        }

        public Ball[] GetBalls(int count, int type = 0)
        {
            var balls = new Ball[count];
            for (var i = 0; i < count; i++)
                balls[i] = Ball(type);

            return balls;
        }
    }
}
