using System;
using ALM.Util.UIToolkitExtend.Elements;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Mathematics;
using Cysharp.Threading.Tasks;

namespace ALM.Common
{
    [RequireComponent(typeof(UIDocument))]
    public class ColorPickerUI : MonoBehaviour
    {
        VisualElement _outside;
        VisualElement _mainElement;
        ColorPicker _pickerElement;
        AlphaPicker _alphaElement;
        Label _rgbLabel;
        VisualElement _colorBlock;

        public Color Color
        {
            get => _pickerElement.Color;
            set
            {
                _pickerElement.Color = value;
                UpdateColor();
            }
        }

        void Awake()
        {
            _outside = GetComponent<UIDocument>().rootVisualElement.Q("Outside");

            _mainElement = _outside.Q("MainPanel");
            _pickerElement = _mainElement.Q<ColorPicker>();
            _rgbLabel = _mainElement.Q<Label>();
            _colorBlock = _mainElement.Q<VisualElement>("ColorBlock");
            _alphaElement = _mainElement.Q<AlphaPicker>();

            _mainElement.Q<VisualElement>("ColorBlockBg").style.backgroundImage =
                new(RuntimeResources.TransparencyGrid);

            BindEvent();
            UpdateColor();

            SetActive(false);
        }

        void BindEvent()
        {
            _pickerElement.OnChangeColor += _ => UpdateColor();
        }

        void UpdateColor()
        {
            _rgbLabel.text = $"RGB(#{ColorUtility.ToHtmlStringRGB(Color)})";
            _colorBlock.style.backgroundColor = Color;
            _alphaElement.Color = Color;
        }

        #region public methods
        public abstract record OpenArg();
        public record OpenArgs(params OpenArg[] Args) : OpenArg;
        public record OpenBy(Vector2 Position, float Scale = 1) : OpenArg;
        public record WithAlpha : OpenArg;

        public void ConfigColor(
            OpenArg arg,
            Action<Color> setter,
            Color color = default)
        {
            ResolveArg(arg);
            var setterAction = GetColorSetter(setter);
            _outside.RegisterCallback<ClickEvent>(ReturnCheck);

            Color = color;
            _pickerElement.OnChangeColor += setterAction;

            SetActive(true);

            void ReturnCheck(ClickEvent e)
            {
                if (e.target != _outside)
                    return;

                SetActive(false);

                _outside.UnregisterCallback<ClickEvent>(ReturnCheck);
                _pickerElement.OnChangeColor -= setterAction;
            }
        }

        public async UniTask<Color> ConfigColorAsync(
            OpenArg arg,
            Action<Color> setter,
            Color color = default)
        {
            ResolveArg(arg);

            var setterAction = GetColorSetter(setter);
            Color = color;
            bool flag = false;
            _outside.RegisterCallback<ClickEvent>(Checker);
            _pickerElement.OnChangeColor += setterAction;
            SetActive(true);

            await UniTask.WaitUntil(() => flag);

            _outside.UnregisterCallback<ClickEvent>(Checker);
            _pickerElement.OnChangeColor -= setterAction;

            SetActive(false);
            return Color;

            void Checker(ClickEvent e) => flag = (e.target == _outside);
        }

        public void SetActive(bool active)
        {
            if (active)
            {
                _outside.RemoveFromClassList("hide");
                return;
            }

            _outside.AddToClassList("hide");
            _alphaElement.style.display = DisplayStyle.None;
        }
        #endregion

        void ResolveArg(OpenArg arg)
        {
            if (arg is null)
                return;

            switch (arg)
            {
                case OpenArgs args:
                    foreach (var item in args.Args)
                        ResolveArg(item);
                    break;

                case OpenBy openBy:
                    MappingUI(openBy.Position, openBy.Scale);
                    break;

                case WithAlpha _:
                    _alphaElement.style.display = DisplayStyle.Flex;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        void MappingUI(Vector2 position, float scale)
        {
            var converted = 1 / scale;
            _outside.style.scale = new(Vector2.one * scale);
            Length lengthConvert = new(converted * 100f, LengthUnit.Percent);

            _outside.style.width = lengthConvert;
            _outside.style.height = lengthConvert;

            var bound = _mainElement.layout;
            bound.width *= scale;
            bound.height *= scale;

            var leftMax = Screen.width - bound.width;
            var topMax = Screen.height - bound.height;

            TransformOrigin anchor = new(Length.Percent(0), Length.Percent(0));

            if (position.x + bound.width > Screen.width)
            {
                position.x -= bound.width;
                anchor.x = Length.Percent(100);
            }

            if (position.y + bound.height > Screen.height)
            {
                position.y -= bound.height;
                anchor.y = Length.Percent(100);
            }

            _mainElement.style.transformOrigin = anchor;
            _mainElement.style.left = math.clamp(position.x, 0, leftMax) * converted;
            _mainElement.style.top = math.clamp(position.y, 0, topMax) * converted;
        }

        Action<Color> GetColorSetter(Action<Color> setter)
        {
            if (_alphaElement.style.display == DisplayStyle.None)
                return setter;

            return _ => setter(_alphaElement.Color);
        }
    }
}