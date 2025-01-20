using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Cysharp.Threading.Tasks;
using VContainer;
using UnityEngine.UIElements;

namespace ALM.Screens.Menu
{
    using ALM.Common;
    using ALM.Screens.Base;
    using ALM.Util;

    public class MissionRepos : MenuUIBase
    {
        public override uint Index => ((uint)UIIndex.MissionRepos);
        protected override string BaseElementName => "MissionRepos";

        [Inject]
        MissionImporter _missionImporter;

        VisualElement _selectionInner;
        List<Button> _buttons { get; } = new();

        protected override void AfterConfig()
        {
            base.AfterConfig();

            _selectionInner = _elementBase.Q(name: "SelectionInner");
        }

        public override void Push()
        {
            base.Push();

            _buttons.ForEach(button => _selectionInner.Remove(button));
            _buttons.Clear();

            _missionImporter.GetMissionRepoList()
                .Repos.ToList().ForEach(
                    r =>
                    {
                        Button button = new();
                        button.text = r.Name;
                        button.RegisterCallback<ClickEvent>(_ => OnSelectRepo(r));
                        _selectionInner.Add(button);

                        _buttons.Add(button);
                    }
                );
        }

        void OnSelectRepo(Data.MissionRepo r)
        {
            UIStackHandler.PushUI((uint)UIIndex.RepoMissions, r);
        }
    }
}