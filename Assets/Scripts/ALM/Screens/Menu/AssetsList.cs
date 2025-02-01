using System.Linq;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    using ALM.Util;
    using Common;

    public class AssetsList : MenuUIBase
    {
        protected override string BaseElementName => "AssetsList";
        public override uint Index => ((uint)UIIndex.AssetsList);

        List<Button> _buttons = new();
        ScrollView _selectionInner;

        protected override void AfterConfig()
        {
            base.AfterConfig();
            _selectionInner = _elementBase.Q<ScrollView>(name: "SelectionInner");
        }

        public override void Push()
        {
            base.Push();

            _selectionInner.contentContainer.Clear();
            _buttons.Clear();

            if (UIStackHandler.Current().data is not EType t)
                return;

            var path = FileIO.GetPath(t switch
            {
                EType.Versions => "../",
                EType.Missions => Constants.MISSION_PATH,
                EType.Customize => Constants.CUSTOMIZE_PATH,
                _ => ""
            });

            // FIXME: 之後需要有 Asset Database 管理
            (t switch
            {
                EType.Versions => System.IO.Directory.GetDirectories(path, "v*.*.*"),
                EType.Missions => System.IO.Directory.GetDirectories(path),
                EType.Customize => System.IO.Directory.GetFiles(path),
                _ => Enumerable.Empty<string>()
            }).ToList().ForEach(p =>
            {
                var name = System.IO.Path.GetFileName(p);

                Button button = new();
                button.text = name;
                button.RegisterCallback<ClickEvent>(_ => { });
                _selectionInner.contentContainer.Add(button);

                _buttons.Add(button);
            });
        }

        public enum EType
        {
            Missions,
            Customize,
            Versions
        }
    }
}