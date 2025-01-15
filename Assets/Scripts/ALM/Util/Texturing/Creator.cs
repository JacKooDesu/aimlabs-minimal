using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;

namespace ALM.Util.Texturing
{
    public class Creator
    {
        public static Texture2D New(int width, int height, Color baseColor = default)
        {
            Texture2D texture = new Texture2D(width, height);

            var colors = Enumerable.Repeat(baseColor, width * height).ToArray();
            texture.SetPixels(colors);
            texture.Apply();

            return texture;
        }

        public static Texture2D New(Camera camera, Rect? size = null)
        {
            var rt = RenderTexture.GetTemporary(
                camera.pixelWidth, camera.pixelHeight, 1, RenderTextureFormat.ARGB32);
            Texture2D texture;

            camera.targetTexture = rt;
            camera.Render();

            UniTask<AsyncGPUReadbackRequest> task;
            if (size is not null)
            {
                var r = size.Value!;
                var (x, y, width, height) =
                    ((int)r.x, (int)r.y, (int)r.width, (int)r.height);

                texture = new Texture2D(width, height, TextureFormat.ARGB32, false);
                task = AsyncGPUReadback.Request(
                    rt, 0, x, width, y, height, 0, 1, TextureFormat.ARGB32).ToUniTask();
            }
            else
            {
                texture = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
                task = AsyncGPUReadback.Request(rt, 0, TextureFormat.ARGB32).ToUniTask();
            }

            task.ContinueWith(OnComplete).Forget();
            return texture;

            void OnComplete(AsyncGPUReadbackRequest req)
            {
                texture.LoadRawTextureData(req.GetData<Color32>());
                texture.Apply();

                RenderTexture.ReleaseTemporary(rt);
                camera.targetTexture = null;
            }
        }
    }
}