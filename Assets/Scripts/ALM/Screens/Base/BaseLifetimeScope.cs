using VContainer;
using VContainer.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace ALM.Screens.Base
{
    using ALM.Common;
    using ALM.Screens.Menu;
    using ALM.Screens.Mission;
    using ALM.Util;
    using ALM.Util.UIToolkitExtend;
    using Realms;
    using Setting;

    public class BaseLifetimeScope : LifetimeScope
    {
        [UnityEngine.SerializeField]
        AudioMapSO _audioMap;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BaseEntry>();
            builder.Register<GameStatusHandler>(Lifetime.Singleton);
            builder.Register<AudioService>(Lifetime.Singleton);
            builder.Register<Realm>(
                _ => Realm.GetInstance(
                    new RealmConfiguration(FileIO.GetPath(Constants.DB_PATH))
                    {
                        SchemaVersion = (ulong)VersionChecker.CurrentVersionInt,
                        MigrationCallback = VersionChecker.DbMigration
                    }),
                Lifetime.Singleton);

            builder.Register<GameplaySetting>(
                _ => GameplaySetting.Load(),
                Lifetime.Singleton);

            builder.Register<ControlSetting>(
                _ => ControlSetting.Load(),
                Lifetime.Singleton);

            builder.Register<ObjectSetting>(
                _ => ObjectSetting.Load(),
                Lifetime.Singleton);

            builder.Register<AudioSetting>(
                r =>
                {
                    var setting = AudioSetting.Load();
                    r.Inject(setting);
                    return setting;
                },
                Lifetime.Singleton);

            builder.Register<MissionLoader>(Lifetime.Singleton);

            builder.Register<MissionImporter>(Lifetime.Singleton);

            builder.RegisterComponentInHierarchy<SettingPanel>();
            builder.RegisterComponentInHierarchy<Room>();
            builder.RegisterComponentInHierarchy<ColorPickerUI>();
            builder.RegisterComponentInHierarchy<QuickHint>();

            builder.RegisterInstance(_audioMap);
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("ALM/Reload Game")]
#endif
        // TODO: Implement ReloadGame method
        public static void ReloadGame()
        { }

        public static void Restart()
        {
#if UNITY_EDITOR
            Debug.LogWarning("Restarting is not supported in the editor.");
            return;
#else
            System.Diagnostics.Process.Start(
                Application.dataPath + "/../" +
#if UNITY_STANDALONE_WIN
                Application.productName + "_Win64.exe"
#elif UNITY_STANDALONE_LINUX
                // FIXME: Linux build path
                Application.productName
#endif
                );

            Application.Quit();
#endif
        }
    }
}

