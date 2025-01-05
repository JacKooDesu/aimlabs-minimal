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
            if (_objectSetting?.GetRoomTexture() is Texture2D tex)
                _room?.SetTexture(tex);
        }
    }
}
