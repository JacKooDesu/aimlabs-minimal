using System;
using System.Linq;
using UnityEngine;

namespace ALM
{
    public static class RuntimeResources
    {
        public static Texture2D TransparencyGrid => _transparencyGrid ??= CreateTransparencyGrid();
        static Texture2D _transparencyGrid;
        static Texture2D CreateTransparencyGrid()
        {
            var tex = new Texture2D(16, 16);
            var colors = new Color[16 * 16];
            var offset = 0;
            var gridSize = 8;

            for (var y = 0; y < 16; y++)
            {
                for (var x = 0; x < 16; x++)
                {
                    colors[y * 16 + x] =
                        ((x + offset) / gridSize) % 2 == 0 ?
                        new(1, 1, 1) : new(0.5f, 0.5f, 0.5f);
                }
                if ((y + 1) % gridSize == 0)
                    offset += gridSize;
            }

            tex.SetPixels(colors);
            tex.Apply();
            tex.wrapMode = TextureWrapMode.Repeat;
            tex.filterMode = FilterMode.Point;
            return tex;
        }

        public static Material DefaultLitMaterial =>
            _defaultLitMaterial ??= new Material(Shader.Find("Universal Render Pipeline/Lit"));
        static Material _defaultLitMaterial;
        public static Material DefaultUnlitMaterial =>
            _defaultUnlitMaterial ??= new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        static Material _defaultUnlitMaterial;

        /// <summary>
        /// Return a copy of default cube mesh
        /// </summary>
        public static Mesh CubeMesh() =>
            (_cubeMesh ??= Resources
                .GetBuiltinResource<Mesh>("Cube.fbx").Copy())
                .Copy();
        static Mesh _cubeMesh;
        /// <summary>
        /// Return a copy of default cube mesh
        /// </summary>
        public static Mesh QuadMesh() =>
            (_quadMesh ??= Resources
                .GetBuiltinResource<Mesh>("Quad.fbx").Copy())
                .Copy();
        static Mesh _quadMesh;

        static Mesh Copy(this Mesh mesh,
            bool uv = true,
            bool normals = true,
            bool tangents = true) =>
            new()
            {
                vertices = mesh.vertices.ToArray(),
                triangles = mesh.triangles.ToArray(),
                uv = uv ? mesh.uv.ToArray() : Array.Empty<Vector2>(),
                normals = normals ? mesh.normals.ToArray() : Array.Empty<Vector3>(),
                tangents = tangents ? mesh.tangents.ToArray() : Array.Empty<Vector4>(),
            };
    }
}
