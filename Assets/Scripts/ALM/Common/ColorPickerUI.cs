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
        }

        #region public methods
        public abstract record OpenArg();
        public abstract record OpenArgs(OpenArg[] Args) : OpenArg;
        public record OpenBy(Vector2 Position, float Scale = 1) : OpenArg;

        public void ConfigColor(
            OpenArg arg,
            Action<Color> setter,
            Color color = default)
        {
            if (arg is OpenBy openBy)
            {
                MappingUI(openBy.Position, openBy.Scale);
            }
            _outside.RegisterCallback<ClickEvent>(ReturnCheck);

            Color = color;
            _pickerElement.OnChangeColor += setter;

            SetActive(true);

            void ReturnCheck(ClickEvent e)
            {
                if (e.target != _outside)
                    return;

                SetActive(false);

                _outside.UnregisterCallback<ClickEvent>(ReturnCheck);
                _pickerElement.OnChangeColor -= setter;
            }
        }

        public async UniTask<Color> ConfigColorAsync(
            OpenArg arg,
            Action<Color> setter,
            Color color = default)
        {
            if (arg is OpenBy openBy)
                MappingUI(openBy.Position, openBy.Scale);

            Color = color;
            bool flag = false;
            _outside.RegisterCallback<ClickEvent>(Checker);
            _pickerElement.OnChangeColor += setter;
            SetActive(true);

            await UniTask.WaitUntil(() => flag);

            _outside.UnregisterCallback<ClickEvent>(Checker);
            _pickerElement.OnChangeColor -= setter;

            SetActive(false);
            return Color;

            void Checker(ClickEvent e) => flag = (e.target == _outside);
        }

        public void SetActive(bool active)
        {
            if (active)
                _outside.RemoveFromClassList("hide");
            else
                _outside.AddToClassList("hide");
        }
        #endregion

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
    }
}