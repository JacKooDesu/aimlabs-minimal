using System.Collections.Generic;
using GLTFast;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace ALM.Screens.Mission
{
    using Util;

    public class GltfLoaderService
    {
        Dictionary<string, _GltfHandle> _gltfs = new();
        string _basePath = "";

        public GltfLoaderService() { }

        public static async UniTask<GltfLoaderService> Create(
            Dictionary<string, string> resPaths, string basePath)
        {
            var service = new GltfLoaderService();
            service._basePath = basePath;

            await UniTask.WhenAll(
                resPaths.Select(x =>
                    UniTask.Create(async () =>
                        await service.Register(x.Key, x.Value))));

            return service;
        }

        public async UniTask Register(string name, string path)
        {
            path = System.IO.Path.Combine(_basePath, path);

            var import = await FileIO.LoadGltfAsync(new(path, FileIO.PathType.Absolute));

            _gltfs.TryAdd(
                name,
                await (new _GltfHandle()).Setup(import, name));

            path.Dbg("Registered gltf: ");
        }

        public GameObject Get(string name)
        {
            GameObject result = null;
            if (_gltfs.TryGetValue(name, out var handle))
                result = handle.Pool.Get();

            return result;
        }

        public void Release(string name, GameObject go)
        {
            if (_gltfs.TryGetValue(name, out var handle))
                handle.Pool.Release(go);
        }

        class _GltfHandle
        {
            Transform _root;
            GameObject _origin;
            public GltfImport Gltf;
            public ObjectPool<GameObject> Pool;
            // bool _isReady;

            public async UniTask<_GltfHandle> Setup(GltfImport gltf, string name = "")
            {
                _root = new GameObject(name).transform;
                _root.gameObject.SetActive(false);

                _origin = new GameObject("Origin");
                _origin.transform.SetParent(_root);

                this.Gltf = gltf;
                await Gltf.InstantiateMainSceneAsync(_origin.transform)
                    .AsUniTask();

                Pool = new(
                    createFunc: Create,
                    actionOnGet: OnGet,
                    actionOnRelease: OnRelease);

                return this;
            }


            GameObject Create()
            {
                GameObject result;

                result = UnityEngine.Object.Instantiate(_origin, parent: _root);

                return result;
            }

            void OnGet(GameObject go)
            {
                go.transform.SetParent(null);
            }

            void OnRelease(GameObject go)
            {
                go.transform.SetParent(_root);
            }

            public void Dispose()
            {
                Pool.Dispose();
                Gltf.Dispose();
            }
        }
    }
}