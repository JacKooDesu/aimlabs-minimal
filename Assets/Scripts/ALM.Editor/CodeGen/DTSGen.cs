#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

using System.IO;
using System.Collections.Generic;

using Puerts.Editor.Generator;

public class DTSGen : MonoBehaviour
{
    const string TARGET_GEN = "aimlabs-minimal-ts-gen/Typing";
    const string ORIGIN_CSHARP_GEN = "/Gen/Typing";
    const string ORIGIN_PUERTS_GEN = "/Puerts/Typing";

    [MenuItem("ALM/Generate index.d.ts", false, 1)]
    static void GenerateDTS()
    {
        UnityMenu.GenerateDTS();
        UpdateDTS();
    }

    [MenuItem("ALM/Update index.d.ts", false, 2)]
    static void UpdateDTS()
    {
        List<string> sourcePaths = new();

        var targetPath = UnityEngine.Application.dataPath + "/../" + TARGET_GEN;
        var csharpPath = UnityEngine.Application.dataPath + ORIGIN_CSHARP_GEN;
        var puertsPath = UnityEngine.Application.dataPath + ORIGIN_PUERTS_GEN;

        Directory.CreateDirectory(csharpPath);

        sourcePaths.Add(csharpPath);
        sourcePaths.Add(puertsPath);

        foreach (var source in sourcePaths)
        {
            var files = Directory.GetFiles(
                source, "*.d.ts", SearchOption.AllDirectories);
            foreach (var path in files)
            {
                var dest = path.Replace(source, targetPath);
                var destDir = Path.GetDirectoryName(dest);

                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);

                File.Copy(path, dest, true);
            }
        }
    }
}
#endif