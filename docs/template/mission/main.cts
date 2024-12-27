import { service, configure as c } from "./core/alm-mission.cjs";

// this is method for unity side to bind all service to core
// should not be removed if u dont know what u doing
export function configure() {
  return c;
}

// this is method unity side called after `configure()` method called
// if u r using service that provided by core, u should place ur logic here
export function entry() { }
