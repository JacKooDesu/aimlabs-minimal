const V3 = CS.UnityEngine.Vector3;
const stayTime = 3;
const distanceZ = 10;
const moveDstHalf = 5;
const moveDst = moveDstHalf * 2;
const speedMin = 3;
const speedMax = 6;

export var service: CS.ALM.Screens.Mission.JsConfigure;
export function configure(s: CS.ALM.Screens.Mission.JsConfigure) {
  return (service = s);
}

let ball: CS.ALM.Screens.Mission.Ball;
let timer = 0;
let x = 0;
let dir = 1;
let speedCurrent;

export function entry() {
  ball = service.BallPool.Ball(0).HasHpBar();

  ball.add_OnHit(calhp);

  resetBall();
  setInterval(moveBall);
}

function calhp() {
  timer -= CS.UnityEngine.Time.deltaTime;
  if (timer <= 0) resetBall();
}

function resetBall() {
  speedCurrent = Math.random() * (speedMax - speedMin) + speedMin;
  x = (Math.random() - 0.5) * moveDst;
  ball.transform.position = new V3(x, 0, distanceZ);

  timer = stayTime;
}

function moveBall() {
  if (x < -moveDstHalf) dir = 1;
  if (x > moveDstHalf) dir = -1;

  x += dir * speedCurrent * CS.UnityEngine.Time.deltaTime;

  ball.transform.Translate(
    new V3(dir * speedCurrent * CS.UnityEngine.Time.deltaTime, 0, 0)
  );

  ball.Hp = timer / stayTime;
}
