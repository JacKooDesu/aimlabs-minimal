using ALM.Util.UIToolkitExtend.Elements;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Mathematics;

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

        public void ConfigColor(OpenArg arg)
        {
            if (arg is OpenBy openBy)
            {
                MappingUI(openBy.Position, openBy.Scale);
            }
            _outside.RegisterCallback<ClickEvent>(ReturnCheck);

            SetActive(true);

            void ReturnCheck(ClickEvent e)
            {
                if (e.target != _outside)
                    return;

                SetActive(false);
                _outside.UnregisterCallback<ClickEvent>(ReturnCheck);
            }
        }

        public void SetActive(bool active)
        {
            _outside.visible = active;
        }
        #endregion

        void MappingUI(Vector2 position, float scale)
        {
            _mainElement.style.scale = new(Vector2.one * scale);
            var bound = _mainElement.worldBound;

            var leftMax = Screen.width - bound.width;
            var topMax = Screen.height - bound.height;

            if (position.x + bound.width > Screen.width)
                position.x -= bound.width;

            if (position.y + bound.height > Screen.height)
                position.y -= bound.height;

            _mainElement.style.left = math.clamp(position.x, 0, leftMax);
            _mainElement.style.top = math.clamp(position.y, 0, topMax);
        }
    }
}