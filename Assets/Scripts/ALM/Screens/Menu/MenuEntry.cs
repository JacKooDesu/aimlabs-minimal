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
    public class MenuEntry : HandlableEntry<MenuEntry>
    {
        readonly MainMenu _mainMenu;
        readonly SelectMission _selectMission;

        IEnumerable<MenuUIBase> _menuUIs;

        [Inject]
        Room _room;

        public MenuEntry(
            DiscordHandler discordHandler,
            UIDocument rootUi) : base(rootUi)
        {
            discordHandler.SetActivity(new()
            {
                State = "In Menu",
            });
        }

        public override void Start()
        {
            UIStackHandler.PushUI((uint)UIIndex.MainMenu);

            _room.SetSize(40);
        }

        protected override void ConstTick() { }
    }
}
