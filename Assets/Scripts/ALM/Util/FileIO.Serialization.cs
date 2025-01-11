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
            { typeof(MP3), "mp3" }
        };
        public static ExtensionFilter[] ParseExtension(this Extension extension)
        {
            return extension switch
            {
                ComposeExtension c => c.Types
                    .Select(x => _extensions[x])
                    .Select(x => new ExtensionFilter(x, x))
                    .ToArray(),
                _ => new[] { new ExtensionFilter(
                    _extensions[extension.GetType()], _extensions[extension.GetType()]) }
            };
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
    }
}