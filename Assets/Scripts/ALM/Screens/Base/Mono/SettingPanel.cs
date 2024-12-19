using System.Linq;
using UnityEngine;
using VContainer;

namespace ALM.Screens.Base
{
    using System;
    using Cysharp.Threading.Tasks;
    using Screens.Base.Setting;
    using UnityEngine.UIElements;
    using Util.UIToolkitExtend;

    public class SettingPanel : MonoBehaviour
    {
        [SerializeField]
        DataBinder _gameplaySettingBinder;
        [SerializeField]
        DataBinder _controlSettingBinder;
        [SerializeField]
        DataBinder _graphicSettingBinder;

        [Inject]
        public GameplaySetting _gameplaySetting;
        [Inject]
        public ControlSetting _controlSetting;

        bool _binding = false;

        void Start()
        {
            _gameplaySettingBinder.ManualBuild(
                GameplaySetting.GetBindable(),
                _gameplaySetting);

            _controlSettingBinder.ManualBuild(
                ControlSetting.GetBindable(),
                _controlSetting);

            _controlSettingBinder.Bindings.ForEach(b =>
                b.Element.RegisterCallback<ClickEvent>(e =>
                {
                    if (_binding)
                        return;

                    b.Element.SetEnabled(false);

                    SetKeybind().ContinueWith(
                        key =>
                        {
                            b.Element.SetEnabled(true);
                            if (key is null) return;

                            b.Element.Q<KeybindElement>().value = key.Value;
                        }
                    ).Forget();
                }));
        }

        async UniTask<KeyCode?> SetKeybind()
        {
            _binding = true;

            var keys = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().ToArray();
            KeyCode? input = null;

            await UniTask.WaitUntil(() => keys.Any(k =>
                Input.GetKeyDown(k) &&
                (input = k) is not null));

            _binding = false;

            if (input is KeyCode.Escape)
                return null;

            return input.Dbg();
        }
    }
}