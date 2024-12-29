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
        DataBinder _objectSettingBinder;
        [SerializeField]
        DataBinder _graphicSettingBinder;

        [Inject]
        public GameplaySetting _gameplaySetting;
        [Inject]
        public ControlSetting _controlSetting;
        [Inject]
        public ObjectSetting _objectSetting;

        VisualElement _ui;

        public bool Binding { get; private set; }

        CursorLockMode _lastLockMode;

        void Awake()
        {
            _ui = GetComponent<UIDocument>().rootVisualElement;
        }

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
                    if (Binding)
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

            _objectSettingBinder.ManualBuild(
                ObjectSetting.GetBindable(),
                _objectSetting);

            SetActive(false, true);
        }

        async UniTask<KeyCode?> SetKeybind()
        {
            Binding = true;

            var keys = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().ToArray();
            KeyCode? input = null;

            await UniTask.WaitUntil(() => keys.Any(k =>
                Input.GetKeyDown(k) &&
                (input = k) is not null));

            Binding = false;

            if (input is KeyCode.Escape)
                return null;

            return input.Dbg();
        }

        public void SwitchActive()
        {
            if (Binding)
                return;

            SetActive(!_ui.visible);
        }

        public void SetActive(bool active, bool ignoreSave = false)
        {
            _ui.visible = active;

            if (!active && !ignoreSave)
            {
                _gameplaySetting.Save();
                _controlSetting.Save();
                _objectSetting.Save();
            }

            if (active)
            {
                _lastLockMode = UnityEngine.Cursor.lockState;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
            }
            else
                UnityEngine.Cursor.lockState = _lastLockMode;
        }
    }
}