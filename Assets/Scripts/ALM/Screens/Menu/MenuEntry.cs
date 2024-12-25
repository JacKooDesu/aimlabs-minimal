using System.Collections.Generic;
using System.Linq;
using ALM.Common;
using UnityEngine.UIElements;
using VContainer.Unity;

namespace ALM.Screens.Menu
{
    public class MenuEntry : IStartable
    {
        readonly UIDocument _rootUi;
        readonly MainMenu _mainMenu;
        readonly SelectMission _selectMission;

        IEnumerable<MenuUIBase> _menuUIs;

        public MenuEntry(
            UIDocument rootUi,
            IEnumerable<MenuUIBase> menuUIs)
        {
            _rootUi = rootUi;
            _menuUIs = menuUIs;

            UIStackHandler.RegisterUIs(menuUIs);
        }

        public void Start()
        {
            foreach (var ui in _menuUIs)
                ui.Config(_rootUi.rootVisualElement);
            
            UIStackHandler.PushUI((uint)UIIndex.MainMenu);
        }
    }
}
