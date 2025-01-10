using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace ALM.Util
{
    public static partial class FileIO
    {
        readonly static string SAVE_PATH =
#if UNITY_EDITOR
            Application.dataPath + "/../v" + Application.version;
#else
            Application.persistentDataPath + '/v' + Application.version;
#endif

        readonly static DirectoryInfo _saveDirInfo = new(SAVE_PATH);

        [RuntimeInitializeOnLoadMethod]
        static void InitDirectories()
        {
            Directory.CreateDirectory(SAVE_PATH);
            Directory.CreateDirectory(Constants.SETTING_PATH);
        }

        public static void JSave<T>(
            T obj, string path, string name,
            params JsonConverter[] converters)
        {
            string json = JsonConvert.SerializeObject(obj, converters);
            var absolutePath = GetPath(path, name);

            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath));
            File.WriteAllText(absolutePath.Dbg("saving: "), json);
        }

        public static void JSave<T>(
            T obj, string filePath,
            params JsonConverter[] converters)
        {
            string json = JsonConvert.SerializeObject(obj, converters);
            var absolutePath = GetPath(filePath);

            Directory.CreateDirectory(Path.GetDirectoryName(absolutePath));
            File.WriteAllText(absolutePath.Dbg("saving: "), json);
        }

        public static T JLoad<T>(
            string path, string name,
            bool createDefault = false,
            params JsonConverter[] converters)
        {
            var filePath = GetPath(path, name).Dbg("loading: ");

            if (createDefault && !File.Exists(filePath))
            {
                var obj = System.Activator.CreateInstance<T>();
                JSave(obj, path, name, converters);
                return obj;
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json, converters);
        }

        public static T JLoad<T>(
            string filePath,
            bool createDefault = false,
            params JsonConverter[] converters)
        {
            filePath = GetPath(filePath);
            if (createDefault && !File.Exists(filePath))
            {
                var obj = System.Activator.CreateInstance<T>();
                JSave(obj, filePath);
                return obj;
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json, converters);
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

        public static void CopyDirectory(string source, string dest)
        {
            if (!Directory.Exists(dest))
                Directory.CreateDirectory(dest);

            foreach (var file in Directory.GetFiles(source))
            {
                var destFile = Path.Combine(dest, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (var folder in Directory.GetDirectories(source))
            {
                var destFolder = Path.Combine(dest, Path.GetFileName(folder));
                CopyDirectory(folder, destFolder);
            }
        }

        public static void OpenFolder(string path, bool absolutePath = false) =>
            Process.Start(new ProcessStartInfo
            {
                FileName = absolutePath ? path : GetPath(path),
                UseShellExecute = true
            });
    }
}
