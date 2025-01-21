using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Screens.Base
{
    public class LoadingPanel : MonoBehaviour
    {
        VisualElement _root;
        VisualElement _rotator;
        bool _active = false;

        void Awake()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _rotator = GetComponent<UIDocument>().rootVisualElement.Q<Label>("Rotator");
            SetActive(false);
        }

        void Update()
        {
            // _root.style.rotate = new Rotate(Angle.Degrees(Time.time * 100));
            // _root.transform.rotation = Quaternion.Euler(0, 0, Time.time * 100);
        }

        async UniTask Rotating()
        {
            while (_active)
            {
                _rotator.transform.rotation = Quaternion.Euler(0, 0, Time.time * 100);
                await UniTask.Yield();
            }
        }

        public async UniTask ShowAsync(UniTask task)
        {
            SetActive(true);
            Rotating().Forget();
            await task;
            SetActive(false);
        }

        public void ShowSync(UniTask task, Action callback = null)
        {
            var t = callback is null ?
                ShowAsync(task) :
                ShowAsync(task).ContinueWith(callback);

            t.Forget();
        }

        void SetActive(bool active)
        {
            if (active)
                _root.RemoveFromClassList("hide");
            // gameObject.SetActive(true);
            else
                _root.AddToClassList("hide");
            // gameObject.SetActive(false);

            _active = active;
        }
    }
}
