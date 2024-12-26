// ALM mission service core v 1.0.0

export namespace service {
  export var raycaster: CS.ALM.Screens.Mission.RaycasterService;
  export var ballPool: CS.ALM.Screens.Mission.BallPoolService;
}

export function configure(config: CS.ALM.Screens.Mission.JsConfigure) {
  service.raycaster = config.Raycaster;
  service.ballPool = config.BallPool;
}
