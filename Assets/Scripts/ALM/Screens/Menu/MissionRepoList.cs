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
    using ALM.Data;
    using ALM.Screens.Base;
    using ALM.Util;

    public class MissionSources : MenuUIBase
    {
        public override uint Index => ((uint)UIIndex.MissionSources);
        protected override string BaseElementName => "MissionSources";

        [Inject]
        MissionImporter _missionImporter;
        [Inject]
        LoadingPanel _loadingPanel;

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

            var endpoints = _missionImporter.GetMissionSources();

            _loadingPanel.ShowSync(
                UniTask.WhenAll(
                    endpoints.Select(e => CreateButton(e))));

            async UniTask CreateButton(string endpoint)
            {
                var sourceDataResponse = await _missionImporter.GetSourceContent(endpoint, true);

                Button button = new();
                button.text = sourceDataResponse.Name;
                button.RegisterCallback<ClickEvent>(_ => OnSelectRepo(endpoint));
                _selectionInner.Add(button);

                _buttons.Add(button);
            }
        }

        void OnSelectRepo(string endpoint)
        {
            UIStackHandler.PushUI((uint)UIIndex.RepoMissions, endpoint);
        }
    }
}