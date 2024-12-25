using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    using Common;

    public class MissionInfo : MenuUIBase
    {
        protected override string BaseElementName => "MissionInfo";
        public override uint Index => ((uint)UIIndex.MissionInfo);

        protected override void AfterConfig()
        {
            base.AfterConfig();
        }
    }
}
