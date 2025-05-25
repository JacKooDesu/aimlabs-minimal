const V3 = CS.UnityEngine.Vector3;

const ballCount = 8;
const distanceZ = 40;
const size = 20;

export const balls: CS.ALM.Screens.Mission.Ball[] = [];

export function setupBalls(
  ballPool: CS.ALM.Screens.Mission.BallPoolService,
  rng: CS.ALM.Util.Rng
) {
  for (let i = 0; i < ballCount; ++i) {
    let ball = ballPool.Ball(0);

    resetBall(ball, rng);
    balls.push(ball);
  }
}

export function resetBall(
  ball: CS.ALM.Screens.Mission.Ball,
  rng: CS.ALM.Util.Rng
) {
  ball.transform.position = new V3(
    rng.FloatRange(-size, size),
    rng.FloatRange(-size, size),
    distanceZ
  );
}
