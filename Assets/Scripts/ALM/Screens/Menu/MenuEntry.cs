using System.Collections.Generic;
using System.Linq;
using ALM.Common;
using ALM.Screens.Base;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

namespace ALM.Screens.Menu
{
    public class MenuEntry : HandlableEntry
    {
        readonly MainMenu _mainMenu;
        readonly SelectMission _selectMission;

        IEnumerable<MenuUIBase> _menuUIs;

        [Inject]
        Room _room;

        public MenuEntry(UIDocument rootUi) : base(rootUi)
        {
        }

        public override void Start()
        {
            UIStackHandler.PushUI((uint)UIIndex.MainMenu);

            _room.SetSize(40);
        }
    }
}
