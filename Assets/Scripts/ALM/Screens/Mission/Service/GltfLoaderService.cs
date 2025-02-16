using System;
using System.Collections.Generic;
using GLTFast;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace ALM.Screens.Mission
{
    using Util;

    public class GltfLoaderService : IDisposable
    {
        Dictionary<string, IGltfHandle> _gltfs = new();
        string _basePath = "";

        public GltfLoaderService() { }
        public GltfLoaderService(string basePath) =>
            _basePath = basePath;

        public async UniTask RegisterSingle(
            string name, string path) =>
            await Register(name, path, new SingleInstanceHandle());

        public async UniTask RegisterPool(
            Dictionary<string, string> resPaths) =>
            await UniTask.WhenAll(
                resPaths.Select(x => UniTask.Create(async () =>
                    await RegisterPool(x.Key, x.Value))));

        public async UniTask RegisterPool(string name, string path) =>
            await Register(name, path, new PooledHandle());

        async UniTask Register<T>(string name, string path, T handle) where T : IGltfHandle
        {
            path = System.IO.Path.Combine(_basePath, path);
            var import = await FileIO.LoadGltfAsync(new(path, FileIO.PathType.Absolute));

            _gltfs.TryAdd(
                name,
                await handle.Setup(import, name));

            path.Dbg("Registered gltf: ");
        }

        public bool TryGetHandle(string name, out IGltfHandle handle) =>
            _gltfs.TryGetValue(name, out handle);
        public bool TryGet(string name, out GameObject go)
        {
            go = null;
            if (!TryGetHandle(name, out var handle))
                return false;

            go = handle.Get();
            return true;
        }

        public GameObject Get(string name)
        {
            if (!TryGet(name, out var go))
                return null;

            return go;
        }

        public void Release(string name, GameObject go)
        {
            if (_gltfs.TryGetValue(name, out var handle))
                handle.Release(go);
        }

        public void Dispose()
        {
            foreach (var handle in _gltfs.Values)
                handle.Dispose();
        }

        public interface IGltfHandle : IDisposable
        {
            GameObject Get();
            void Release(GameObject go);
            public UniTask<IGltfHandle> Setup(GltfImport gltf, string name = "");
        }

        class SingleInstanceHandle : IGltfHandle
        {
            GameObject _instance;
            public async UniTask<IGltfHandle> Setup(GltfImport gltf, string name = "")
            {
                var instantiator = new GameObjectInstantiator(gltf, null);
                var result = await gltf.InstantiateMainSceneAsync(instantiator)
                    .AsUniTask();

                if (!result)
                    throw new System.Exception("Failed to setup gltf: " + name);

                _instance = instantiator.SceneTransform.gameObject;
                _instance.name = name;

                return this;
            }

            public GameObject Get() => _instance;
            public void Release(GameObject go) =>
                Debug.LogWarning("You can't release single instance handle");

            public void Dispose() =>
                UnityEngine.Object.Destroy(_instance);
        }

        class PooledHandle : IGltfHandle
        {
            Transform _root;
            GameObject _origin;
            GltfImport _gltf;
            ObjectPool<GameObject> _pool;

            public async UniTask<IGltfHandle> Setup(GltfImport gltf, string name = "")
            {
                _root = new GameObject(name + "_pool").transform;
                _root.gameObject.SetActive(false);

                this._gltf = gltf;
                var result = await _gltf.InstantiateMainSceneAsync(_root)
                    .AsUniTask();

                if (!result)
                    throw new System.Exception("Failed to setup gltf: " + name);

                _origin = _root.GetChild(0).gameObject;
                _origin.name = name;

                _pool = new(
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

            public GameObject Get() => _pool.Get();
            public void Release(GameObject go) => _pool.Release(go);

            public void Dispose()
            {
                _pool.Dispose();
                _gltf.Dispose();
            }
        }
    }
}