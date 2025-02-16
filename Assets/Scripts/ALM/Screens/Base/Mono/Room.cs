using System.Collections.Generic;
using System.Linq;
using ALM.Screens.Base.Setting;
using UnityEngine;
using VContainer;

namespace ALM.Screens.Base
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class Room : MonoBehaviour
    {
        public const float DEFAULT_TEXTURE_SCALER = 10f;

        [Inject]
        ObjectSetting _objectSetting;

        MeshRenderer _renderer;
        MeshFilter _filter;
        float _size;

        [SerializeField]
        Texture _fallbackTexture;

        void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _filter = GetComponent<MeshFilter>();

            _renderer.material = RuntimeResources.DefaultLitMaterial;
            _filter.mesh = FlippedCube();

            _objectSetting.OnChange += nm =>
            {
                if (nm == nameof(ObjectSetting.RoomTextureScale))
                    SetSize(_size);
            };
        }

        public void SetTexture(Texture texture)
        {
            _renderer.material.mainTexture = texture;
        }

        public void SetTextureSafe(Texture texture)
        {
            if (texture == null)
                texture = _fallbackTexture;

            SetTexture(texture);
        }

        public void SetSize(float size)
        {
            _size = size;
            transform.localScale = Vector3.one * size;
            _renderer.material.SetTextureScale("_BaseMap",
                Vector2.one * size / (_objectSetting?.RoomTextureScale ?? DEFAULT_TEXTURE_SCALER));
        }

        Mesh FlippedCube()
        {
            var cube = RuntimeResources.CubeMesh();
            List<int> triangles = new List<int>(cube.triangles);
            triangles.Reverse();
            cube.SetTriangles(triangles.ToArray(), 0);
            cube.RecalculateNormals();

            return cube;
        }
    }
}
