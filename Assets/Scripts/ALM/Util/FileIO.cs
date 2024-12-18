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
            Application.dataPath;
#else
            Application.persistentDataPath;
#endif

        public static void JSave<T>(T obj, string path)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
        }

        public static T JLoad<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }

        static string GetSavePath(string subPath, string name)
        {
            var path = Path.Combine(SAVE_PATH, subPath, name);
            Directory.CreateDirectory(path);
            return path;
        }
    }
}
