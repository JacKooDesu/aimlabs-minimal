const V3 = CS.UnityEngine.Vector3;
const minRadius = 1;
const maxRadius = 5;
const distanceZ = 10;

export var service: CS.ALM.Screens.Mission.JsConfigure;
export function configure(s: CS.ALM.Screens.Mission.JsConfigure) {
  return (service = s);
}

const balls: CS.ALM.Screens.Mission.Ball[] = [];
let iter: number = 0;

export function entry() {
  balls.push(service.BallPool.Ball(0));
  balls.push(service.BallPool.Ball(0));

  balls.forEach((ball, i) => {
    ball.transform.position = new V3(0, 0, distanceZ);
    ball.add_OnHit(next);
  });

  next();
}

function next() {
  let ball = balls[iter];
  ball.gameObject.SetActive(false);

  iter = (iter + 1) % 2;
  ball = balls[iter];
  if (iter == 0) {
    let angle = Math.random() * Math.PI * 2;
    let radius = Math.random() * (maxRadius - minRadius) + minRadius;
    let x = Math.cos(angle) * radius;
    let y = Math.sin(angle) * radius;

    ball.transform.position = new V3(x, y, distanceZ);
  }

  balls[iter].gameObject.SetActive(true);
}
