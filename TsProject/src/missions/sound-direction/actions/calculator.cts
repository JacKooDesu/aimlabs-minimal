const maxDeg = 30;

export function OnCasted(
  ball: CS.ALM.Screens.Mission.Ball,
  service: CS.ALM.Screens.Mission.JsConfigure,
  caster: CS.ALM.Screens.Mission.IRaycaster,
  _: CS.ALM.Screens.Mission.IRaycastTarget
): void {
  let dir = calDeg(caster.Direction.x, caster.Direction.z);
  let ballDir = calDeg(ball.transform.position.x, ball.transform.position.z);

  let diff = Math.abs(dir - ballDir);
  if (diff < maxDeg) service.ScoreData.Score += 500 * (1 - diff / maxDeg);
}

function calDeg(x: number, z: number) {
  let deg = (Math.atan2(x, z) * 180) / Math.PI;
  if (deg < 0) deg += 360;
  return deg;
}
