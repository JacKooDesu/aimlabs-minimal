using System;
using ALM.Common;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    public class MainMenu : MenuUIBase
    {
        protected override string BaseElementName => "MainPanel";
        public override uint Index => (uint)UIIndex.MainMenu;

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _elementBase.Q<Button>("SelectMission").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.SelectMission));
        }
    }
}
