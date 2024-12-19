using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    using Screens.Base.Setting;
    using Util.UIToolkitExtend;

    public class BaseEntry : IStartable, ITickable
    {
        // FIXME: 之後要統一管理 UI Layers
        [Inject]
        SettingPanel _settingPanel;

        public void Start()
        {
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                _settingPanel.SwitchActive();
        }
    }
}
