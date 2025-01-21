using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace ALM.Screens.Base
{
    public class QuickHint : MonoBehaviour
    {
        VisualElement _mainElement;
        Label _textElement;

        float _hideTime;
        float _displayTime;

        void Awake()
        {
            _mainElement = GetComponent<UIDocument>().rootVisualElement.Q("MainPanel");
            _textElement = _mainElement.Q<Label>();

            SetActive(false);
        }

        public async UniTask Show(string text, float time, bool skipable = true)
        {
            _textElement.text = text;
            SetActive(true);

            var delay = UniTask.Delay((int)(time * 1000));
            if (skipable)
            {
                await UniTask.WhenAny(
                    UniTask.WaitUntil(() => Input.GetMouseButtonDown(0)),
                    delay);
            }
            else
                await delay;
            SetActive(false);
        }

        public void ShowSync(string text, float time, bool skipable = true, Action callback = null)
        {
            var task = callback is null ?
                Show(text, time, skipable) :
                Show(text, time, skipable).ContinueWith(callback);

            task.Forget();
        }

        public async UniTask Queue(IEnumerable<string> messgaes, float time, bool skipable = true)
        {
            foreach (var msg in messgaes)
                await Show(msg, time, skipable);
        }

        void SetActive(bool active)
        {
            if (active)
                _mainElement.RemoveFromClassList("hide");
            else
                _mainElement.AddToClassList("hide");
        }
    }
}
