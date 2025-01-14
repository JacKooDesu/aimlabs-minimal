var copyfiles = require("copyfiles");

const destMap = {
  win: "../build/StandaloneWindows64",
  linux: "../build/StandaloneLinux64",
};
const dest = destMap[process.argv[2]] || "./output/";

copyfiles(
  ["src/missions/**/*", dest],
  { up: 1, verbose: true, exclude: ["src/**/*.*ts"] },
  function (err) {
    if (err) {
      console.error(err);
    } else {
      console.log("copy complete!");
    }
  }
);
