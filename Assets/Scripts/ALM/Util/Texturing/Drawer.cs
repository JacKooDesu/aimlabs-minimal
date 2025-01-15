using System.Linq;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ALM.Util.Texturing
{
    public class Drawer
    {
        public Texture2D Tex { get; private set; }

        public Drawer(Texture2D texture, bool withOffset = false)
        {
            Tex = texture;
            // Tex.filterMode = FilterMode.Point;
        }

        public Drawer Fill(Color color)
        {
            Tex.SetPixels(
                Enumerable.Repeat(color, Tex.width * Tex.height).ToArray());
            return this;
        }
        public Drawer Clear() =>
            Fill(Color.clear);

        public Drawer Line(Vector2Int from, Vector2Int to, Color color)
        {
            var dx = math.abs(to.x - from.x);
            var dy = math.abs(to.y - from.y);

            var stepX = dx is 0 ? 0 :
                to.x < from.x ? -1 : 1;
            var stepY = dy is 0 ? 0 :
                to.y < from.y ? -1 : 1;

            // find bigger one
            var err = dx - dy;
            var e2 = 2 * err;

            while (true)
            {
                Tex.SetPixel(from.x, from.y, color);
                if (from.x == to.x && from.y == to.y) break;
                if (e2 > -dy)
                {
                    err -= dy;
                    from.x += stepX;
                }
                if (e2 < dx)
                {
                    err += dx;
                    from.y += stepY;
                }

                e2 = 2 * err;
            }

            return this;
        }

        public Drawer Circle(Vector2Int center, int radius, Color color)
        {
            int x, y;

            int max = (int)(radius * .707f);

            for (x = 0; x <= max; ++x)
            {
                y = 0;
                // 得圓的邊界
                while (x * x + y * y - radius * radius <= 0)
                    y++;

                // 如果超出邊界，則回退一格
                y = x * x + y * y - radius * radius - y < 0 ?
                    y : y - 1;

                var size = y - x;
                var colors = Enumerable.Repeat(color, size).ToArray();

                var xa = center.x + x;
                var ya = center.y + x;
                var xb = center.x - x;
                var yb = center.y - y + 1;

                Tex.SetPixels(
                    xa, ya, 1, size, colors);
                Tex.SetPixels(
                    xb, ya, 1, size, colors);
                Tex.SetPixels(
                    xa, yb, 1, size, colors);
                Tex.SetPixels(
                    xb, yb, 1, size, colors);

                Tex.SetPixels(
                    ya, xa, size, 1, colors);
                Tex.SetPixels(
                    ya, xb, size, 1, colors);
                Tex.SetPixels(
                    yb, xa, size, 1, colors);
                Tex.SetPixels(
                    yb, xb, size, 1, colors);
            }

            return this;
        }

        public Drawer Donut(Vector2Int center, int outerRadius, int innerRadius, Color color)
        {
            int x, maxY, minY;

            int max = (int)(outerRadius * .707f);
            int min = (int)(innerRadius * .707f);

            for (x = 0; x <= max; ++x)
            {
                maxY = 0;
                minY = 0;
                // 得圓的邊界
                while (x * x + maxY * maxY - outerRadius * outerRadius <= 0)
                    maxY++;

                while (x * x + minY * minY - innerRadius * innerRadius <= 0)
                    minY++;
                // 如果超出邊界，則回退一格
                maxY = x * x + maxY * maxY - outerRadius * outerRadius - maxY < 0 ?
                    maxY : maxY - 1;
                minY = x * x + minY * minY - innerRadius * innerRadius - minY < 0 ?
                    minY : minY - 1;

                var size = maxY - minY;
                var colors = Enumerable.Repeat(color, size).ToArray();

                var xa = center.x + x;
                var ya = center.y + x;
                var xb = center.x - x;
                var yb = center.y - maxY + 1;

                Tex.SetPixels(
                    xa, center.y + minY, 1, size, colors);
                Tex.SetPixels(
                    xb, center.y + minY, 1, size, colors);
                Tex.SetPixels(
                    xa, yb, 1, size, colors);
                Tex.SetPixels(
                    xb, yb, 1, size, colors);

                Tex.SetPixels(
                    center.y + minY, xa, size, 1, colors);
                Tex.SetPixels(
                    center.y + minY, xb, size, 1, colors);
                Tex.SetPixels(
                    yb, xa, size, 1, colors);
                Tex.SetPixels(
                    yb, xb, size, 1, colors);
            }

            return this;
        }

        public Drawer SymmetryLeftRight(bool inverse = false)
        {
            var width = Tex.width / 2;
            var height = Tex.height;

            var from = !inverse ? 0 : width;
            var to = !inverse ? width : 0;

            Enumerable.Range(0, height)
                .AsParallel()
                .ForAll(y =>
                {
                    var src = Tex.GetPixels(from, y, width, 1);
                    Tex.SetPixels(to, y, width, 1, src.Reverse().ToArray(), 0);
                });

            return this;
        }

        public Drawer SymmetryTopBottom(bool inverse = false)
        {
            var width = Tex.width;
            var height = Tex.height / 2;

            // note: in viewport, y=0 is bottom
            var from = !inverse ? height : 0;
            var to = !inverse ? 0 : height;

            Enumerable.Range(0, width)
                .AsParallel()
                .ForAll(x =>
                {
                    var src = Tex.GetPixels(x, from, width, 1);
                    Tex.SetPixels(x, to, width, 1, src.Reverse().ToArray(), 0);
                });

            return this;
        }

        public Drawer Rectangle(Vector2Int p, int width, int height, Color color)
        {
            width = math.clamp(width, 0, Tex.width - p.x);
            height = math.clamp(height, 0, Tex.height - p.y);

            var arr = Enumerable.Repeat(color, width * height).ToArray();
            Tex.SetPixels(p.x, p.y, width, height, arr);
            return this;
        }

        public Drawer Rectangle(int fromX, int fromY, int toX, int toY, Color color)
        {
            var width = toX - fromX;
            var height = toY - fromY;
            return Rectangle(
                new Vector2Int(
                    width > 0 ? fromX : toX,
                    height > 0 ? fromY : toY),
                math.abs(width), math.abs(height), color);
        }

        public void Apply() => Tex.Apply();
    }
}
