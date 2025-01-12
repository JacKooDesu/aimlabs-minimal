using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Base
{
    using ALM.Screens.Menu;
    using Screens.Base.Setting;
    using Util.UIToolkitExtend;

    public class BaseEntry : IStartable, IInitializable
    {
        [Inject]
        Room _room;
        [Inject]
        ObjectSetting _objectSetting;

        public void Initialize()
        { }

        public void Start()
        {
            UpdateRoomTexture();
            _objectSetting.OnChange += nm =>
            {
                if (nm == nameof(ObjectSetting.RoomTextureName))
                    UpdateRoomTexture();
            };
        }

        void UpdateRoomTexture()
        {
            _room?.SetTextureSafe(_objectSetting?.GetRoomTexture());
        }
    }
}
