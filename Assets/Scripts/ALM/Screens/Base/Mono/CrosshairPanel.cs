using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using Puerts;
using System;
using ALM.Util.UIToolkitExtend.Elements;
using ALM.Util;
using TsEnvCore;
using Unity.Profiling;
using ALM.Util.UIToolkitExtend;

namespace ALM.Screens.Base
{
    public class CrosshairPanel : MonoBehaviour
    {
        VisualElement _ui;
        VisualElement _scenePreview;
        VisualElement _crosshairPreview;
        ScrollView _optionView;
        Button _applyButton;
        Button _discardButton;

        Texture2D _canvas;
        JsEnv _jsEnv;
        OptionSetting _setting;
        Action<Texture2D> _crosshairRenderer;

        void Awake()
        {
            _ui = GetComponent<UIDocument>().rootVisualElement
                .Q("CrosshairConfig");

            _scenePreview = _ui.Q("ScenePreview");
            _crosshairPreview = _ui.Q("CrosshairPreview");
            _optionView = _ui.Q<ScrollView>("Options");
            _applyButton = _ui.Q<Button>("Apply");
            _discardButton = _ui.Q<Button>("Discard");

            _applyButton.RegisterCallback<ClickEvent>(OnApply);
            _discardButton.RegisterCallback<ClickEvent>(OnDiscard);
        }

        void OnDestroy()
        {
            _jsEnv?.Dispose();
        }

        void OnDiscard(ClickEvent evt)
        {
            SetActive(false);
        }

        void OnApply(ClickEvent evt)
        {
            SetActive(false);
        }

        public void SetActive(bool active)
        {
            if (!active)
            {
                _ui.AddToClassList("hide");
                _jsEnv?.Dispose();
                return;
            }

            for (int i = _optionView.contentContainer.childCount; i > 0; --i)
                _optionView.contentContainer.RemoveAt(0);

            _ui.RemoveFromClassList("hide");

            _ui.MarkDirtyRepaint();
            // cal size after one frame
            UniTask.Yield().ToUniTask()
                .ContinueWith(SetPreview).Forget();

            LoadJs();

            void SetPreview()
            {
                var width = _scenePreview.worldBound.width;
                var height = _scenePreview.worldBound.height;

                var tex = Util.Texturing.Creator.New(
                        Camera.main,
                        new Rect(
                            (Screen.width - width) / 2,
                            (Screen.height - height) / 2,
                            width, height));

                SetPreviewBg(tex);
            }
        }

        void LoadJs()
        {
            var loader = new LoaderCollection();
            loader.AddLoader(new TsEnvCore.RootBasedLoader(FileIO.GetPath(Constants.SYSTEM_SCRIPT_PATH)));
            loader.AddLoader(new Puerts.DefaultLoader());
            _jsEnv = new JsEnv(loader);
            _jsEnv.UsingFunc<Func<OptionSetting>>();
            _jsEnv.UsingFunc<Func<Texture2D>>();
            _jsEnv.UsingFunc<Action<Texture2D>>();

            var module = _jsEnv.ExecuteModule(FileIO.GetPath(Constants.SYSTEM_SCRIPT_PATH, "crosshair-config.cjs"));
            var func = module.Get<Func<OptionSetting>>("binding");
            var createFunc = module.Get<Func<Texture2D>>("create");

            _canvas = createFunc?.Invoke();
            _crosshairRenderer = module.Get<Action<Texture2D>>("render");
            _setting = func?.Invoke();

            SetPreviewCrosshair(_canvas);

            var binder = new DataBinderCS(_optionView, _setting.Bindables, _setting);
            _setting.OnChange += _ => _crosshairRenderer.Invoke(_canvas);

            var options = func?.Invoke();
        }

        public void SetPreviewBg(Texture2D texture)
        {
            _scenePreview.style.backgroundImage = new(texture);
        }

        public void SetPreviewCrosshair(Texture2D texture)
        {
            _crosshairPreview.style.width = texture.width;
            _crosshairPreview.style.height = texture.height;
            _crosshairPreview.style.backgroundImage = new(texture);
        }

        public class OptionSetting : VirtaulDataTarget
        {
            public Bindable[] Bindables { get; set; }
        }
    }
}
