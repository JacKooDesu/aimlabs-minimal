using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SFB;

namespace ALM.Util
{
    public static partial class FileIO
    {
        public enum PathType
        {
            Absolute,
            Relative
        }

        [JsonObject]
        public abstract class _File
        {
            [JsonProperty("path")]
            public string path;
            [JsonProperty("type")]
            public PathType type;

            [JsonIgnore]
            public readonly Extension extension;

            public _File(string path, PathType type, Extension extension)
            {
                this.path = path;
                this.type = type;
                this.extension = extension;
            }

            public static _File Absolute(string path) =>
                new AnomoyousFile(path, PathType.Absolute);
            public static _File Relative(string path) =>
                new AnomoyousFile(path, PathType.Relative);

            class AnomoyousFile : _File
            {
                public AnomoyousFile(string path, PathType type) :
                    base(path, type, null)
                { }
            }

            public static implicit operator string(_File file) =>
                file.type == PathType.Relative ?
                    GetPath(file.path) : file.path;
        }

        public class File<T> : _File
            where T : Extension
        {
            public File(string path, PathType type = PathType.Relative) :
                base(path, type, Activator.CreateInstance<T>())
            { }
        }

        static Dictionary<Type, string> _extensions = new()
        {
            { typeof(ALL), "*" },
            { typeof(JSON), "json" },
            { typeof(OGG), "ogg" },
            { typeof(PNG), "png" },
            { typeof(JPG), "jpg" },
            { typeof(WAV), "wav" },
            { typeof(MP3), "mp3" },
            { typeof(ZIP), "zip" },
            { typeof(CJS), "cjs" },
            { typeof(TXT), "txt" },
        };
        public static ExtensionFilter[] ParseExtension(this Extension extension)
        {
            string ext;
            if (extension is ComposeExtension c)
            {
                ExtensionFilter[] arr = new ExtensionFilter[c.Types.Length + 1];
                for (int i = 0; i < c.Types.Length; ++i)
                {
                    ext = _extensions[c.Types[i]];
                    arr[i + 1] = new ExtensionFilter(ext, ext);
                }
                arr[0] = new ExtensionFilter("All",
                    arr[1..].SelectMany(x => x.Extensions).ToArray());

                return arr;
            }

            ext = _extensions[extension.GetType()];
            return new[] { new ExtensionFilter(ext, ext) };
        }

        public abstract record Extension();
        public record ComposeExtension(Type[] Types) : Extension
        {
            public static ComposeExtension Create(params Type[] types)
            {
                if (types.Any(x => x.BaseType != typeof(Extension)))
                    throw new ArgumentException("Invalid type");

                return new ComposeExtension(types);
            }
        }

        public record Compose<T1, T2>() : ComposeExtension(new[] { typeof(T1), typeof(T2) })
            where T1 : Extension
            where T2 : Extension;
        public record Compose<T1, T2, T3>() : ComposeExtension(new[] { typeof(T1), typeof(T2), typeof(T3) })
            where T1 : Extension
            where T2 : Extension
            where T3 : Extension;
        public record Compose<T1, T2, T3, T4>() : ComposeExtension(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) })
            where T1 : Extension
            where T2 : Extension
            where T3 : Extension
            where T4 : Extension;

        public record ALL() : Extension();
        public record JSON() : Extension();
        public record OGG() : Extension();
        public record WAV() : Extension();
        public record MP3() : Extension();
        public record PNG() : Extension();
        public record JPG() : Extension();
        public record ZIP() : Extension();
        public record CJS() : Extension();
        public record TXT() : Extension();
    }
}