using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Puerts;
using Unity;
using UnityEngine;

namespace TsEnvCore
{
    record LoaderData(ILoader Loader, int Index = int.MaxValue);

    public class LoaderCollection : ILoader
    {
        List<LoaderData> _loaders { get; } = new();
        Dictionary<string, ILoader> _lazyFileLoaderDict { get; } = new();
        
        public LoaderCollection(params ILoader[] loaders)
        {
            _loaders.AddRange(
                loaders.Select(x => new LoaderData(x)));
        }

        public void AddLoader(ILoader loader, int index = int.MaxValue)
        {
            _loaders.Add(new(loader, index));
            _loaders.Sort((v1, v2) =>
                v1.Index > v2.Index ? 1 : v1.Index < v2.Index ? -1 : 0);
        }

        public bool FileExists(string filepath)
        {
            // lazy path dict here
            var found = _loaders.FirstOrDefault(x => x.Loader.FileExists(filepath));
            if (found is null)
                return false;

            _lazyFileLoaderDict.Add(filepath, found.Loader);
            return true;
        }

        public string ReadFile(string filepath, out string debugpath)
        {
            if (_lazyFileLoaderDict.TryGetValue(filepath, out var loader))
                return loader.ReadFile(filepath, out debugpath);
            else
                throw new Exception();
        }
    }

    public class Loader : ILoader
    {
        readonly Func<string, bool> _validator;

        public Loader(params string[] defaultPaths)
        {
            _validator = (path) =>
                defaultPaths.Any(x => path.StartsWith(x));
        }

        public bool FileExists(string filepath)
        {
            // return _validator(filepath);
            return File.Exists(GetPath(filepath));
        }

        public string ReadFile(string filepath, out string debugpath)
        {
            filepath = filepath.Replace('/', '\\');

            debugpath = "";

#if UNITY_EDITOR
            var path = GetPath(filepath);
            Debug.Log("Load: " + path);

            return File.ReadAllText(path);
#endif
        }

        string GetPath(string file)
        {
#if UNITY_EDITOR
            return Path.Combine(Directory.GetCurrentDirectory() + "\\TsProject\\output\\", file);
#else
            return file;
#endif
        }
    }
}