using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace ALM.Util
{
    public static class FileIO
    {
        readonly static string SAVE_PATH =
#if UNITY_EDITOR
            Application.dataPath + "/../";
#else
            Application.persistentDataPath;
#endif

        readonly static DirectoryInfo _saveDirInfo = new(SAVE_PATH);

        [RuntimeInitializeOnLoadMethod]
        static void InitDirectories()
        {
            Directory.CreateDirectory(SAVE_PATH);
            Directory.CreateDirectory(Constants.SETTING_PATH);
        }

        public static void JSave<T>(T obj, string path, string name)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(GetPath(path, name).Dbg("saving: "), json);
        }

        public static void JSave<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(GetPath(filePath).Dbg("saving: "), json);
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

        public static T JLoad<T>(string filePath, bool createDefault = false)
        {
            filePath = GetPath(filePath);
            if (createDefault && !File.Exists(filePath))
            {
                var obj = System.Activator.CreateInstance<T>();
                JSave(obj, filePath);
                return obj;
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        internal static Texture2D LoadTexture(string texturePath)
        {
            var path = GetPath(Constants.CUSTOMIZE_PATH, texturePath);
            if (!File.Exists(path.Dbg("texture")))
                return null;

            byte[] bytes = File.ReadAllBytes(path);
            Texture2D texture = new(2, 2);
            texture.LoadImage(bytes);
            return texture;
        }

        public static string GetPath(string subPath, string name = "")
        {
            var path = Path.Combine(SAVE_PATH, subPath);
            return Path.Combine(SAVE_PATH, subPath, name);
        }
    }
}
