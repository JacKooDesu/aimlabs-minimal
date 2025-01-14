const V3 = CS.UnityEngine.Vector3;

// setup ball 4x4 grid
const interval = 1.5;
const distanceZ = 10;
const rowCount = 4;
const colCount = 4;

export const balls: CS.ALM.Screens.Mission.Ball[] = [];

export function setupBalls(ballPool: CS.ALM.Screens.Mission.BallPoolService) {
  let offsetX = (colCount - 1) / 2;
  let offsetY = (rowCount - 1) / 2;
  for (let i = 0; i < rowCount; ++i) {
    for (let ii = 0; ii < colCount; ++ii) {
      let ball = ballPool.Ball(0);

      let x = (ii - offsetX) * interval;
      let y = (i - offsetY) * interval;
      ball.transform.position = new V3(x, y, distanceZ);

      balls.push(ball);
    }
  }

  // shuffle balls
  balls.sort(() => Math.random() - 0.5);
}
