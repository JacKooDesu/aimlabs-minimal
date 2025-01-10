using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using Cysharp.Threading.Tasks;

namespace ALM.Screens.Base
{
    using ALM.Common;
    using ALM.Util.UIToolkitExtend.Elements;
    using Screens.Base.Setting;
    using Util;
    using Util.UIToolkitExtend;

    public class SettingPanel : MonoBehaviour
    {
        public const uint INDEX = 1 << 10;

        [SerializeField]
        DataBinder _gameplaySettingBinder;
        [SerializeField]
        DataBinder _controlSettingBinder;
        [SerializeField]
        DataBinder _objectSettingBinder;
        [SerializeField]
        DataBinder _graphicSettingBinder;
        [SerializeField]
        DataBinder _audioSettingBinder;

        [Inject]
        public GameplaySetting _gameplaySetting;
        [Inject]
        public ControlSetting _controlSetting;
        [Inject]
        public ObjectSetting _objectSetting;
        [Inject]
        public AudioSetting _audioSetting;

        [Inject]
        ColorPickerUI ColorPickerUI;
        [Inject]
        GameStatusHandler _gameStatusHandler;

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
                _objectSetting.GetBindable(),
                _objectSetting);

            _objectSettingBinder.Bindings
                .ForEach(b =>
                {
                    if (b.Element is not ColorBindElement element)
                        return;

                    element.OnClickColorBlock += e =>
                    {
                        Binding = true;
                        ColorPickerUI.ConfigColorAsync(
                            new ColorPickerUI.OpenBy(e.position),
                            c => element.value = c,
                            element.value)
                            .ContinueWith(_ => Binding = false)
                            .Forget();
                    };
                });

            _audioSettingBinder.ManualBuild(
                _audioSetting.GetBindable(),
                _audioSetting);

            // setup file input
            _objectSettingBinder.Bindings
                .Concat(_audioSettingBinder.Bindings)
                .ToList()
                .ForEach(b =>
                {
                    if (b.Element is not FileInputElement element)
                        return;

                    element.DefaultRootPath = FileIO.GetPath(Constants.CUSTOMIZE_PATH);
                    element.FileProcessor = f => FileProcessor(element.value, f);
                });

            SetActive(false, true);

            FileIO._File FileProcessor(FileIO._File origin, string file)
            {
                if (!File.Exists(file))
                    return origin;
                if (file.Contains(FileIO.GetPath(Constants.CUSTOMIZE_PATH)))
                    return origin;

                var name = Path.GetFileName(file);
                var dest = FileIO.GetPath(Constants.CUSTOMIZE_PATH, name);
                File.Copy(file, dest, true);

                origin.path = name;

                return origin;
            }
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

        public void SetActive(bool active, bool ignoreSave = false)
        {
            _ui.visible = active;

            if (!active && !ignoreSave)
            {
                _gameplaySetting.Save();
                _controlSetting.Save();
                _objectSetting.Save();
                _audioSetting.Save();
            }
        }

        public async UniTask ActiveAsync(
            Action onClose = null, Func<bool> closeCondition = null)
        {
            SetActive(true);
            closeCondition ??= () => Input.GetKeyDown(KeyCode.Escape);
            await UniTask.WaitUntil(() => closeCondition() && !Binding);
            SetActive(false);
            onClose?.Invoke();
        }
    }
}