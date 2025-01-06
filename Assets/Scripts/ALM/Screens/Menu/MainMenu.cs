using System;
using ALM.Common;
using ALM.Screens.Base;
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

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _elementBase.Q<Button>("SelectMission").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.SelectMission));

            _elementBase.Q<Button>("Setting").RegisterCallback<ClickEvent>(
                OpenSetting);

            _elementBase.Q<Button>("ImportMission").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.ImportMission));
        }

        void OpenSetting(ClickEvent _)
        {
            _settingPanel.ActiveAsync().Forget();
        }
    }
}
