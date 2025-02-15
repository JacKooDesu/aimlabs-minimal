const V3 = CS.UnityEngine.Vector3;
const Path = CS.System.IO.Path;
const FileIO = CS.ALM.Util.FileIO;

const minRadius = 5;
const maxRadius = 10;
const angleMax = (15 / 180) * Math.PI; // lr so need doubled

export var service: CS.ALM.Screens.Mission.JsConfigure;
export function configure(s: CS.ALM.Screens.Mission.JsConfigure) {
  return (service = s);
}

let target: CS.ALM.Screens.Mission.AnomoyousRaycastTarget;

export function entry() {
  target = CS.ALM.Screens.Mission.AnomoyousRaycastTarget.Setup(
    service.GltfLoader.Get("rig"),
    true
  );

  next();

  target.add_OnHit(() => next());
}

function next() {
  let angle = service.Rng.FloatRange(-angleMax, +angleMax);
  angle += Math.PI / 2 + angle; // 0 degree is at the top
  let radius = service.Rng.Float() * (maxRadius - minRadius) + minRadius;
  let x = Math.cos(angle) * radius;
  let z = Math.sin(angle) * radius;

  target.transform.position = new V3(x, 0, z);
}
