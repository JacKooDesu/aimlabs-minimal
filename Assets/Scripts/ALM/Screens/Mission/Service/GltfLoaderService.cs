using System.Collections.Generic;
using GLTFast;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace ALM.Screens.Mission
{
    using System;
    using Util;

    public class GltfLoaderService
    {
        Dictionary<string, _GltfHandle> _gltfs = new();

        public GltfLoaderService() { }

        public static GltfLoaderService Create(Dictionary<string, string> resPaths)
        {
            var service = new GltfLoaderService();

            foreach (var (key, path) in resPaths)
                service.Register(key, path);

            return service;
        }

        public void Register(string name, string path)
        {
            _gltfs.TryAdd(
                name,
                new(FileIO.LoadGltfSync(new(path)), name));
        }

        public void Get(string name)
        {
            if (_gltfs.TryGetValue(name, out var handle))
                handle.Pool.Get();
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
            bool _isReady;

            public _GltfHandle(GltfImport gltf, string name = "")
            {
                _root = new GameObject(name).transform;
                _root.gameObject.SetActive(false);

                _origin = new GameObject("Origin");
                _origin.transform.SetParent(_root);

                this.Gltf = gltf;
                _isReady = false;

                Pool = new(
                    createFunc: Create,
                    actionOnGet: OnGet,
                    actionOnRelease: OnRelease);

                UniTask.WaitUntil(() => Gltf.LoadingDone || Gltf.LoadingError)
                    .ContinueWith(async () =>
                    {
                        if (Gltf.LoadingError)
                            throw new Exception("Failed to load gltf");

                        await Gltf.InstantiateMainSceneAsync(_origin.transform)
                            .AsUniTask();
                    })
                    .Forget();
            }


            GameObject Create()
            {
                GameObject result;
                if (!_isReady)
                    Gltf.InstantiateMainSceneAsync((result = new()).transform)
                        .AsUniTask()
                        .Forget();
                else
                    result = UnityEngine.Object.Instantiate(_origin);

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