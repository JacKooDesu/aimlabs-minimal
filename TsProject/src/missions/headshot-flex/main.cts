const V3 = CS.UnityEngine.Vector3;
const Path = CS.System.IO.Path;
const FileIO = CS.ALM.Util.FileIO;
const ConfigType = CS.ALM.Util.EventBinder.CollideBasedHandler.AutoConfig;

const minRadius = 5;
const maxRadius = 10;
const angleMax = (15 / 180) * Math.PI; // lr so need doubled

export var service: CS.ALM.Screens.Mission.JsConfigure;
export function configure(s: CS.ALM.Screens.Mission.JsConfigure) {
  return (service = s);
}

let rig;
let raycastTarget: CS.ALM.Screens.Mission.AnomoyousRaycastTarget;

export function entry() {
  rig = service.GltfLoader.Get("rig");

  raycastTarget = CS.ALM.Screens.Mission.AnomoyousRaycastTarget.Setup(
    rig.transform.Find("Scene/Head").gameObject,
    ConfigType.Mesh
  );

  next();

  rig.add_OnHit(() => next());
}

function next() {
  let angle = service.Rng.FloatRange(-angleMax, +angleMax);
  angle += Math.PI / 2 + angle; // 0 degree is at the top
  let radius = service.Rng.Float() * (maxRadius - minRadius) + minRadius;
  let x = Math.cos(angle) * radius;
  let z = Math.sin(angle) * radius;

  rig.transform.position = new V3(x, 0, z);
}
