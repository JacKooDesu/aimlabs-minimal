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

        void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _filter = GetComponent<MeshFilter>();
        }

        public void SetTexture(Texture2D texture)
        {
            _renderer.material.mainTexture = texture;
        }

        public void SetSize(float size)
        {
            transform.localScale = Vector3.one * size;
            _renderer.material.SetTextureScale("_BaseMap",
                Vector2.one * size / (_objectSetting?.RoomTextureScale ?? DEFAULT_TEXTURE_SCALER));
        }
    }
}
