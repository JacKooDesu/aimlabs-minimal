import { OnCasted } from "./actions/calculator.cjs";

const V3 = CS.UnityEngine.Vector3;
const Path = CS.System.IO.Path;
const FileIO = CS.ALM.Util.FileIO;

const minRadius = 5;
const maxRadius = 10;
const showTime = 0.5;

export var service: CS.ALM.Screens.Mission.JsConfigure;
export function configure(s: CS.ALM.Screens.Mission.JsConfigure) {
  return (service = s);
}

export let ball: CS.ALM.Screens.Mission.Ball;
let showing = false;
let clip: CS.UnityEngine.AudioClip;

export function entry() {
  ball = service.BallPool.Ball(0);
  service.Score.OverrideCalculator(
    new CS.ALM.Screens.Mission.JsScoreCalculator((caster, _) =>
      OnCasted(ball, service, caster, _)
    )
  );

  let path = Path.Combine(
    FileIO.GetMissionFolder("sound-direction"),
    "snd.wav"
  );
  service.Raycaster.add_OnCastFinished(casted);

  FileIO.LoadExternalSoundSync(path, (r) => {
    clip = r;
    next();
  });
}

function casted(caster: CS.ALM.Screens.Mission.IRaycaster, _: any) {
  if (showing) return;
  showing = true;
  ball.gameObject.SetActive(true);
  setTimeout(next, showTime * 1000);
}

function next() {
  ball.gameObject.SetActive(false);

  let angle = service.Rng.Float() * Math.PI * 2;
  let radius = service.Rng.Float() * (maxRadius - minRadius) + minRadius;
  let x = Math.cos(angle) * radius;
  let z = Math.sin(angle) * radius;

  ball.transform.position = new V3(x, 0, z);

  service.Audio.PlaySoundAtPos(clip, ball.transform.position);
  showing = false;
}
