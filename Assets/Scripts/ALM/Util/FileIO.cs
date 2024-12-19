using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Util
{
    public static class FileIO
    {
        // public abstract record SaveSetting();

        readonly static string SAVE_PATH =
#if UNITY_EDITOR
            Application.dataPath + "/../";
#else
            Application.persistentDataPath;
#endif

        public static void JSave<T>(T obj, string path, string name)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(GetPath(path, name).Dbg("saving: "), json);
        }

        public static T JLoad<T>(string path, string name, bool createDefault = false)
        {
            var filePath = GetPath(path, name).Dbg("loading: ");

            if (createDefault && !File.Exists(filePath))
            {
                var obj = System.Activator.CreateInstance<T>();
                JSave(obj, path, name);
                return obj;
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        static string GetPath(string subPath, string name)
        {
            var path = Path.Combine(SAVE_PATH, subPath);
            Directory.CreateDirectory(path);
            return Path.Combine(SAVE_PATH, subPath, name);
        }
    }
}
