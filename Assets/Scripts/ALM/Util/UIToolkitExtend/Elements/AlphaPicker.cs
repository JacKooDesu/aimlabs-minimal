using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Util.UIToolkitExtend.Elements
{
    [UxmlElement]
    public partial class AlphaPicker : VisualElement
    {
        [SerializeField, DontCreateProperty]
        Color _color = Color.black;
        [UxmlAttribute, CreateProperty]
        public Color Color
        {
            set
            {
                _color = value;
                _color.a = _slider.value;
            }
        }
        public float Alpha
        {
            get => _slider.value;
            set => _slider.value = value;
        }

        Slider _slider;

        public event Action<Color> OnChangeAlpha;

        // mark obsolete supress warning
        [Obsolete]
        public AlphaPicker()
        {
            generateVisualContent += GenerateVisualContent;

            this.style.backgroundImage = RuntimeResources.TransparencyGrid;
            this.style.unityBackgroundScaleMode = ScaleMode.ScaleToFit;
            this.style.backgroundRepeat = new BackgroundRepeat(Repeat.Repeat, Repeat.Repeat);

            this.Add(_slider = new Slider(0, 1, SliderDirection.Horizontal));
            _slider.RegisterValueChangedCallback(evt =>
            {
                _color.a = evt.newValue;
                OnChangeAlpha?.Invoke(_color);
                MarkDirtyRepaint();
            });
            _slider.style.opacity = 0f;
            _slider.inverted = true;
        }

        void GenerateVisualContent(MeshGenerationContext context)
        {
            var painter = context.painter2D;
            var rect = contentRect;

            var half = rect.width / 2;

            // draw gradient
            {
                painter.BeginPath();
                painter.lineWidth = rect.height;
                painter.strokeGradient = new()
                {
                    mode = GradientMode.Blend,
                    alphaKeys = new GradientAlphaKey[]
                    {
                        new(0f, 1f),
                        new(1f, 0f)
                    },
                    colorKeys = new GradientColorKey[]
                    {
                        new(_color, 0f),
                    }
                };
                painter.MoveTo(rect.center - new Vector2(half, 0));
                painter.LineTo(rect.center + new Vector2(half, 0));
                painter.Stroke();
                painter.ClosePath();
            }

            // draw handle
            {
                painter.BeginPath();

                painter.strokeColor = Color.black;
                painter.lineWidth = 4;
                painter.Arc(rect.center - new Vector2(rect.width * (_slider.value - .5f), 0), rect.height / 2, 0, 360);
                painter.Stroke();
                painter.ClosePath();
            }
        }
    }
}