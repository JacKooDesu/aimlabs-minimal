import { balls, resetBall, setupBalls } from "./actions/mapSetup.cjs";

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

  balls.forEach((b) => {
    b.add_OnHit(() => resetBall(b, service.Rng));
  });
}
