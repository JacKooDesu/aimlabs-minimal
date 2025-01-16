using System.IO;
using UnityEngine;

namespace ALM.Util
{
    public static partial class FileIO
    {
        public static string SavePNG(this byte[] bytes, string path, string name)
        {
            if (!name.EndsWith(".png"))
                name += ".png";

            var fullPath = GetPath(path, name).Dbg("saving png: ");
            using (var fs = File.Create(fullPath, bytes.Length))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            return fullPath;
        }
    }
}