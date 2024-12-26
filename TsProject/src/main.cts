import { service, configure as c } from "./core/alm-mission.cjs";
import { balls, setupBalls } from "./actions/mapSetup.cjs";

const ballExist = 3;
const ballsActive: CS.ALM.Screens.Mission.Ball[] = [];
const ballsInactive: CS.ALM.Screens.Mission.Ball[] = [];

// this is method for unity side to bind all service to core
// should not be removed if u dont know what u doing
export function configure() {
  return c;
}

// this is method unity side called after `configure()` method called
// if u r using service that provided by core, u should place ur logic here
export function entry() {
  setupBalls(service.ballPool);
  balls.forEach((ball, i) => {
    if (i < ballExist) {
      ballsActive.push(ball);
      ball.gameObject.SetActive(true);
    } else {
      ballsInactive.push(ball);
      ball.gameObject.SetActive(false);
    }
  });

  balls.forEach((ball) => {
    ball.add_OnHit(() => switchBall(ball));
  });
}

function switchBall(ball) {
  ball.gameObject.SetActive(false);

  let rand = Math.random();
  const randomIndex = Math.floor(rand * ballsInactive.length);
  const randomBall = ballsInactive.splice(randomIndex, 1)[0];

  ballsActive.push(randomBall);
  ballsInactive.push(ball);

  randomBall.gameObject.SetActive(true);
}
