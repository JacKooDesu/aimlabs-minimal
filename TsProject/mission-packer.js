const crypto = require("crypto");
const fs = require("fs");
const path = require("path");

const destMap = {
  win: "../build/StandaloneWindows64/missions",
  linux: "../build/StandaloneLinux64/missions",
};
const dest = destMap[process.argv[2]] || "./output" + "/missions";

fs.promises.readdir(dest).then((f, err, _) => {
  if (err) {
    console.error(err);
  }

  return f.map(async (m) => await calMd5(m));
});

async function calMd5(mPath) {
  mPath = path.join(dest, mPath);
  let files = await fs.promises.readdir(mPath, {
    withFileTypes: true,
    recursive: true,
  });
  files = files
    .filter(
      (file) =>
        file.isFile() &&
        !file.name.endsWith(".map") &&
        !file.name.endsWith(".md5")
    )
    .sort((a, b) => a.name.localeCompare(b.name));
  let hash = crypto.createHash("md5");
  files.forEach((file) => {
    let x = path.resolve(file.parentPath, file.name);
    console.log(x);
    let content = fs.readFileSync(x);
    hash.update(content);
    hash.copy();
  });
  let r = hash.digest("hex");
  console.log("md5: " + r);
  console.log("\n");

  fs.writeFile(path.join(mPath, ".md5"), r, () => {});

  return r;
}
