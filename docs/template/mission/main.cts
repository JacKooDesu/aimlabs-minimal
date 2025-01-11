import { a } from "./other-actions/a.cts";
import { b } from "./other-actions/b.cts";

// this is method for unity side to bind all service to core
// should not be removed if u dont know what u doing
export var service: CS.ALM.Screens.Mission.JsConfigure;
export function configure(s: CS.ALM.Screens.Mission.JsConfigure) {
  return (service = s);
}

// this is method unity side called after `configure()` method called
// if u r using service that provided by core, u should place ur logic here
export function entry() { }
