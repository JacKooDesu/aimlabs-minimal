using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    using ALM.Util;
    using Common;

    public class ManageAssets : MenuUIBase
    {
        protected override string BaseElementName => "ManageAssetsPanel";
        public override uint Index => ((uint)UIIndex.ManageAssets);

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _elementBase.Q<Button>("Missions").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.AssetsList, AssetsList.EType.Missions));

            _elementBase.Q<Button>("Customize").RegisterCallback<ClickEvent>(
                _ => UIStackHandler.PushUI((uint)UIIndex.AssetsList, AssetsList.EType.Customize));

            _elementBase.Q<Button>("OpenRoot").RegisterCallback<ClickEvent>(
                _ => FileIO.OpenFolder(""));
        }
    }
}