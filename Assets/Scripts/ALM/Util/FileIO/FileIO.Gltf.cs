using System;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using GLTFast;
using Unity.Collections;
using UnityEngine;

namespace ALM.Util
{
    public static partial class FileIO
    {
        public static async UniTask<GltfImport> LoadGltfAsync(
            File<Compose<GLTF, GLB>> file, CancellationToken ct = default)
        {
            if (!file.TryGetPathSafe(out var path))
                return null;

            var gltf = new GltfImport();

            var success = Path.GetExtension(path) switch
            {
                ".gltf" => await gltf.Load(path, cancellationToken: ct),
                ".glb" => await gltf.Load(File.ReadAllBytes(path), cancellationToken: ct),
                _ => throw new NotSupportedException()
            };

            return gltf;
        }

        public static GltfImport LoadGltfSync(File<Compose<GLTF, GLB>> file)
        {
            if (!file.TryGetPathSafe(out var path))
                return null;

            var gltf = new GltfImport();

            var task = Path.GetExtension(path) switch
            {
                ".gltf" => gltf.Load(path).AsUniTask(),
                ".glb" => gltf.Load(File.ReadAllBytes(path)).AsUniTask(),
                _ => throw new NotSupportedException()
            };

            task.Forget();

            return gltf;
        }
    }
}