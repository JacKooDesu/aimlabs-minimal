var copyfiles = require("copyfiles");

const destMap = {
  win: "../build/AimLabs-Minimal_Win64/mission-import",
  linux: "../build/AimLabs-Minimal_Linux64/mission-import",
};
const dest = destMap[process.argv[2]] || "./output/";

copyfiles(
  ["src/**/*", dest],
  { up: 1, verbose: true, exclude: ["src/**/*.*ts"] },
  function (err) {
    if (err) {
      console.error(err);
    } else {
      console.log("copy complete!");
    }
  }
);
