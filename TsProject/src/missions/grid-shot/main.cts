import { balls, setupBalls } from "./actions/mapSetup.cjs";

const ballExist = 3;
const ballsActive: CS.ALM.Screens.Mission.Ball[] = [];
const ballsInactive: CS.ALM.Screens.Mission.Ball[] = [];

// this is method for unity side to bind all service to core
// should not be removed if u dont know what u doing
export var service: CS.ALM.Screens.Mission.JsConfigure;
export function configure(s: CS.ALM.Screens.Mission.JsConfigure) {
  return (service = s);
}

// this is method unity side called after `configure()` method called
// if u r using service that provided by core, u should place ur logic here
export function entry() {
  setupBalls(service.BallPool, service.Rng);
  balls.forEach((ball, i) => {
    if (i < ballExist) {
      ballsActive.push(ball);
      ball.gameObject.SetActive(true);
    } else {
      ballsInactive.push(ball);
      ball.gameObject.SetActive(false);
    }

    ball.add_OnHit(() => switchBall(ball));
  });
}

function switchBall(ball) {
  ball.gameObject.SetActive(false);

  let rand = service.Rng.IntRange(0, ballsInactive.length);
  const randomBall = ballsInactive.splice(rand, 1)[0];

  ballsActive.push(randomBall);
  ballsInactive.push(ball);

  randomBall.gameObject.SetActive(true);
}
