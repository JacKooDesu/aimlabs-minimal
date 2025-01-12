using System;
using ALM.Common;
using ALM.Screens.Base;
using ALM.Util;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace ALM.Screens.Menu
{
    public class MainMenu : MenuUIBase
    {
        protected override string BaseElementName => "MainPanel";
        public override uint Index => (uint)UIIndex.MainMenu;

        [Inject]
        SettingPanel _settingPanel;

        [Inject]
        MissionImporter _missionImporter;
        [Inject]
        MissionLoader _missionLoader;

        [Inject]
        QuickHint _quickHint;

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _elementBase.Q<Button>("SelectMission").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.SelectMission));

            _elementBase.Q<Button>("Setting").RegisterCallback<ClickEvent>(
                OpenSetting);

            _elementBase.Q<Button>("ImportMission").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.ImportMission));

            _elementBase.Q<Button>("CheckUpdate").RegisterCallback<ClickEvent>(
                CheckAppVersion);

            _elementBase.Q<Button>("ManageAssets").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.ManageAssets));

            _elementBase.parent.Q<Button>("ExitButton").RegisterCallback<ClickEvent>(
                _ => Application.Quit());
        }

        void OpenSetting(ClickEvent _)
        {
            _settingPanel.ActiveAsync().Forget();
        }

        void CheckAppVersion(ClickEvent _)
        {
            VersionChecker.CheckAppVersion()
                .ContinueWith(Result)
                .Forget(Catch);

            void Result(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    _quickHint.Show("Already the latest version", 1.5f).Forget();
                    return;
                }

                Application.OpenURL(s);
            }
            void Catch(Exception e)
            {
                Debug.LogError(e);
                _quickHint.Show(e.Message, 1.5f).Forget();
            }
        }
    }
}
