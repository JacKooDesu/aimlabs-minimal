using System.Linq;
using System.Reflection;

namespace ALM
{
    internal static class Constants
    {
        public const string SETTING_PATH = "settings";
        public const string CUSTOMIZE_PATH = "customize";
        public const string MISSION_PATH = "missions";
        public const string SYSTEM_SCRIPT_PATH = "systems";
        public const string DB_PATH = "database.realm";

        public const string OUTLINE_EXT = ".json";

        public static class Audio
        {
            public const string HIT_SOUND = "hit-sound";
            public const string FIRE_SOUND = "fire-sound";

            public const string BTN_HOVER_SOUND = "button-hover-snd";
            public const string BTN_CLICK_SOUND = "button-click-snd";

            public static string[] AudioKeys() =>
                typeof(Audio).GetFields(
                    BindingFlags.Public |
                    BindingFlags.Static |
                    BindingFlags.FlattenHierarchy)
                    .Where(f => f.IsLiteral && !f.IsInitOnly)
                    .Select(x => x.GetValue(null) as string)
                    .ToArray();
        }

        public static class Url
        {
            public const string GITHUB_REPO = "https://github.com/JacKooDesu/aimlabs-minimal";
        }
    }
}