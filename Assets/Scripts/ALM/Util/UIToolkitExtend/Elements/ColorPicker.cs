using System;
using System.Linq;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Mathematics;

namespace ALM.Util.UIToolkitExtend.Elements
{
    [UxmlElement]
    public partial class ColorPicker : VisualElement
    {
        #region public
        public float H
        {
            get => _h;
            private set
            {
                _h = value;
                SetHSVToRGB();
            }
        }
        float _h;
        public float S
        {
            get => _s;
            private set
            {
                _s = value;
                SetHSVToRGB();
            }
        }
        float _s;
        public float V
        {
            get => _v;
            private set
            {
                _v = value;
                SetHSVToRGB();
            }
        }
        float _v;
        void SetHSVToRGB() => _color = Color.HSVToRGB(H, S, V);

        [SerializeField, DontCreateProperty]
        Color _color = Color.black;
        [UxmlAttribute, CreateProperty]
        public Color Color
        {
            get => _color;
            set
            {
                Color.RGBToHSV(value, out var h, out var s, out var v);
                H = h;
                S = s;
                V = v;
                _color = value;
            }
        }

        public event Action<Color> OnChangeColor;
        #endregion

        static CustomStyleProperty<float> s_ColorRingWidth = new("--color-ring-width");
        float m_colorRingWidth = 0;
        /// <summary>
        /// Auto calculate and cache color ring width if not set
        /// </summary>
        float _ColorRingWidth => m_colorRingWidth is 0 ?
            m_colorRingWidth = math.min(contentRect.width, contentRect.height) * .08f :
            m_colorRingWidth;

        static readonly Vertex[] k_Vertices = new Vertex[3];
        static readonly ushort[] k_Indices = { 0, 2, 1 };

        OperationMode _operationMode = OperationMode.None;

        Gradient _colorRingGradient { get; set; } = new()
        {
            mode = GradientMode.Blend,
            colorKeys = new GradientColorKey[]
            {
                new(Color.HSVToRGB(0f,1,1), 0),
                new(Color.HSVToRGB(1f/6f,1,1), 1f/6f),
                new(Color.HSVToRGB(2f/6f,1,1), 2f/6f),
                new(Color.HSVToRGB(3f/6f,1,1), 3f/6f),
                new(Color.HSVToRGB(4f/6f,1,1), 4f/6f),
                new(Color.HSVToRGB(5f/6f,1,1), 5f/6f),
                new(Color.HSVToRGB(1,1,1), 1),
            }
        };
        Vector2[] _triangleVecs = new[]
        {
            (Vector2)(Quaternion.AngleAxis(120f, Vector3.forward) * Vector2.right),
            Vector2.right,
            (Vector2)(Quaternion.AngleAxis(-120f, Vector3.forward) * Vector2.right),
        };
        float _RingSize =>
            math.min(contentRect.width, contentRect.height) / 2 - _ColorRingWidth / 2;

        /// <summary>
        /// This is prevent user moving outside when controling element
        /// </summary>
        VisualElement _controlingOverlay;

        public ColorPicker()
        {
            generateVisualContent += GenerateVisualContent;
            RegisterCallback<CustomStyleResolvedEvent>(CustomStyleResolver);

            // Dragging mode
            this.RegisterCallback<PointerDownEvent>(OnDragStart);
            this.RegisterCallback<PointerMoveEvent>(OnDragUpdate);
            this.RegisterCallback<PointerUpEvent>(OnDrageEnd);

            this.Add(_controlingOverlay = new VisualElement());
            _controlingOverlay.style.position = Position.Absolute;
            _controlingOverlay.style.top = -Screen.height;
            _controlingOverlay.style.left = -Screen.width;
            _controlingOverlay.style.height = Screen.height * 2;
            _controlingOverlay.style.width = Screen.width * 2;
            _controlingOverlay.style.visibility = Visibility.Hidden;
        }

        void CustomStyleResolver(CustomStyleResolvedEvent e)
        {
            if (e.currentTarget != this)
                return;

            this.UpdateCustomStyle();
        }

        void UpdateCustomStyle()
        {
            bool repaint = false;
            if (customStyle.TryGetValue(s_ColorRingWidth, out m_colorRingWidth))
                repaint = true;

            if (repaint)
                MarkDirtyRepaint();
        }

        void OnDragStart(PointerDownEvent e)
        {
            _operationMode = CheckOperationMode(e.localPosition);
            _controlingOverlay.style.visibility = Visibility.Visible;

            CalColor(e.localPosition - (Vector3)contentRect.position);
        }

        void OnDrageEnd(PointerUpEvent e)
        {
            _operationMode = OperationMode.None;
            _controlingOverlay.style.visibility = Visibility.Hidden;
        }

        void OnDragUpdate(PointerMoveEvent e)
        {
            CalColor(e.localPosition - (Vector3)contentRect.position);
            MarkDirtyRepaint();
        }

        void CalColor(Vector3 localPoint)
        {
            if (_operationMode is OperationMode.None)
                return;

            var rect = contentRect;
            var dir = (Vector2)localPoint - rect.center;

            if (_operationMode is OperationMode.H)
                H = GetHue(dir);
            else if (_operationMode is OperationMode.SV)
            {
                (S, V) = GetSV(localPoint, _RingSize);
            }

            MarkDirtyRepaint();

            OnChangeColor?.Invoke(Color);
        }

        enum OperationMode
        {
            None,
            H,
            SV,
        }

        void GenerateVisualContent(MeshGenerationContext context)
        {
            var rect = contentRect;
            var size = _RingSize;

            // outer ring
            {
                var painter = context.painter2D;
                painter.BeginPath();

                painter.Arc(rect.center, size, 270, -90, ArcDirection.CounterClockwise);
                painter.strokeGradient = _colorRingGradient;
                painter.lineWidth = _ColorRingWidth;
                painter.Stroke();

                painter.ClosePath();

                // draw picker
                var hRad = math.PI2 * H;
                var hPickerPos = rect.center +
                    new Vector2(math.cos(hRad), math.sin(-hRad)) * size;
                DrawPicker(hPickerPos);
            }

            // inner triangle
            {
                var triangleSize = size - _ColorRingWidth / 2;
                var color = Color.HSVToRGB(H, 1, 1);
                k_Vertices[0].tint = Color.HSVToRGB(H, 1, 0);
                k_Vertices[1].tint = Color.HSVToRGB(H, 1, 1);
                k_Vertices[2].tint = Color.HSVToRGB(H, 0, 1);

                // a
                //  |> b
                // c
                float3 c = k_Vertices[0].position =
                    rect.center + _triangleVecs[0] * triangleSize;
                float3 b = k_Vertices[1].position =
                    rect.center + _triangleVecs[1] * triangleSize;
                float3 a = k_Vertices[2].position =
                    rect.center + _triangleVecs[2] * triangleSize;

                var data = context.Allocate(k_Vertices.Length, k_Indices.Length);
                data.SetAllVertices(k_Vertices);
                data.SetAllIndices(k_Indices);

                // draw picker
                var vMid = math.lerp(a, b, .5f);
                var vVec = (vMid - c) * V;
                var sVec = (b - a) * (S - .5f) * V;
                DrawPicker((c + vVec + sVec).xy);
            }

            void DrawPicker(Vector2 pos)
            {
                var painter = context.painter2D;

                painter.BeginPath();
                painter.lineWidth = size * .01f;
                painter.strokeColor = Color.white;
                painter.Arc(pos, size * .02f, 0, 360);
                painter.Stroke();
                painter.ClosePath();

                painter.BeginPath();
                painter.lineWidth = 4;
                painter.strokeColor = Color.black;
                painter.Arc(pos, size * .02f + 8, 0, 360);
                painter.Stroke();
                painter.ClosePath();
            }
        }

        float GetHue(Vector2 dir)
        {
            var angle = -math.atan2(dir.y, dir.x);
            if (angle < 0)
                angle += math.PI2;
            return angle / math.PI2;
        }

        OperationMode CheckOperationMode(Vector2 localPoint)
        {
            var rect = contentRect;
            var length = math.distance(rect.center, localPoint);
            var width = rect.width;
            var height = rect.height;

            // check click on ring
            if (length > _RingSize - _ColorRingWidth / 2 &&
                length < _RingSize + _ColorRingWidth / 2)
                return OperationMode.H;
            else if (CheckInsideTriangle(localPoint))
                return OperationMode.SV;

            return OperationMode.None;
        }

        bool CheckInsideTriangle(Vector2 p)
        {
            Vector2 a = k_Vertices[0].position;
            Vector2 b = k_Vertices[1].position;
            Vector2 c = k_Vertices[2].position;

            var v0 = c - a;
            var v1 = b - a;
            var v2 = p - a;

            var dot00 = Vector2.Dot(v0, v0);
            var dot01 = Vector2.Dot(v0, v1);
            var dot02 = Vector2.Dot(v0, v2);
            var dot11 = Vector2.Dot(v1, v1);
            var dot12 = Vector2.Dot(v1, v2);

            var invDenom = 1 / (dot00 * dot11 - dot01 * dot01);
            var u = (dot11 * dot02 - dot01 * dot12) * invDenom;
            var v = (dot00 * dot12 - dot01 * dot02) * invDenom;

            return (u >= 0) && (v >= 0) && (u + v < 1);
        }

        (float S, float V) GetSV(Vector2 p, float ringSize)
        {
            // a 
            //  |> b
            // c
            var a = k_Vertices[2].position;
            var b = k_Vertices[1].position;
            var c = k_Vertices[0].position;

            var sVecOrigin = a - b;
            var sLengthMax = math.length(sVecOrigin);
            var vVecOrigin = b + (sVecOrigin * .5f) - c;
            var vLengthMax = sLengthMax * 0.5f * math.sqrt(3);

            var sVec = (Vector3)p - c;
            var vVec = math.project(sVec, vVecOrigin);
            var v = math.atan2(vVec.y, vVec.x) > math.PIHALF ?
                0 : math.length(vVec) / vLengthMax;

            var sAngle = Vector3.SignedAngle(vVec, sVec, Vector3.forward);
            var s = math.sin(sAngle * Mathf.Deg2Rad) + .5f;

            return (math.clamp(s, 0, 1f), math.clamp(v, 0, 1f));
        }
    }
}