using UnityEngine;
using UnityEngine.Pool;

namespace ALM.Screens.Mission
{
    using Base.Setting;
    public class BallPoolService
    {
        readonly ObjectSetting _objectSetting;
        public ObjectPool<Ball> Pool { get; private set; }

        readonly Material _material;

        public BallPoolService(ObjectSetting objectSetting)
        {
            _objectSetting = objectSetting;
            Pool = new ObjectPool<Ball>(
                CreateBall,
                GetBall,
                ReleaseBall,
                DestroyBall);

            _material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        }

        Ball CreateBall()
        {
            var ball = GameObject
                .CreatePrimitive(PrimitiveType.Sphere);
            ball.GetComponent<MeshRenderer>().material = _material;
            return ball.AddComponent<Ball>();
        }

        void GetBall(Ball ball) { }
        void ReleaseBall(Ball ball) { }
        void DestroyBall(Ball ball) { }

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
