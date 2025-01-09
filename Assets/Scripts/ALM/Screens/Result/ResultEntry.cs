using UnityEngine.UIElements;

namespace ALM.Screens.Result
{
    using ALM.Common;
    using ALM.Screens.Base;

    public class ResultEntry : HandlableEntry<ResultEntry>
    {
        public ResultEntry(UIDocument rootUi) : base(rootUi)
        {
        }

        public override void Start()
        {
            UIStackHandler.PushUI((uint)UIIndex.ResultMain);
        }
    }
}