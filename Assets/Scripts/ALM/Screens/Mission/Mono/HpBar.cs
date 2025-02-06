using Unity.Mathematics;
using UnityEngine;

namespace ALM.Screens.Mission
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class HpBar : MonoBehaviour
    {
        const float WIDTH = 1f;
        const float HEIGHT = .2f;

        public float Value
        {
            get => _value;
            set
            {
                _value = math.clamp(value, 0f, 1f);
                UpdateMesh();
            }
        }
        float _value = 1f;

        MeshRenderer _renderer;
        MeshFilter _filter;

        void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _filter = GetComponent<MeshFilter>();

            _renderer.material = RuntimeResources.DefaultUnlitMaterial;

            var mesh = new Mesh
            {
                vertices = new Vector3[]
                {
                    new Vector3(-WIDTH / 2, 0, 0),
                    new Vector3(WIDTH / 2, 0, 0),
                    new Vector3(WIDTH / 2, HEIGHT, 0),
                    new Vector3(-WIDTH / 2, HEIGHT, 0),
                },
                triangles = new int[]
                {
                    0, 2, 1,
                    0, 3, 2,
                },
                uv = new Vector2[]
                {
                    new Vector2(0, 0),
                    new Vector2(1, 0),
                    new Vector2(1, 1),
                    new Vector2(0, 1),
                },
            };

            _filter.mesh = mesh;
        }

        void UpdateMesh()
        {
            var mesh = _filter.mesh;
            var vertices = mesh.vertices;
            vertices[1].x = vertices[2].x = WIDTH * (_value - .5f);
            mesh.vertices = vertices;
            _filter.mesh = mesh;
        }
    }
}