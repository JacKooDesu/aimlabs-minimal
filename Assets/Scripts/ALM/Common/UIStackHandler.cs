using System;
using System.Collections.Generic;
using ALM.Screens.Menu;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ALM.Common
{
    public static class UIStackHandler
    {
        public record UI(uint index, UIBase ui, object data = null);
        static UI _NoneUI = new(0, null);
        static Stack<UI> _uiStack = new();
        static Dictionary<uint, UIBase> _uiDict = new();

        static bool _sleeping = false;

        public static event Action<UI> OnPop;
        public static event Action<UI> OnPush;
        public static event Action<UI> OnOverlapped;
        public static event Action<UI> OnReturn;

        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            SceneManager.sceneUnloaded += _ => Reset();
        }

        public static void Reset()
        {
            _uiStack.Clear();
            _uiDict.Clear();

            OnPop = null;
            OnPush = null;
            OnOverlapped = null;
            OnReturn = null;
        }

        public static void PushUI(uint index, object data = null)
        {
            if (_sleeping)
                return;

            if (_uiStack.TryPeek(out var currentUI))
                currentUI.ui?.Overlapped();

            if (_uiDict.TryGetValue((uint)index, out var nextUI))
            {
                _uiStack.Push(new((uint)index, nextUI, data));
                nextUI.Push();
                OnPush?.Invoke(_uiStack.Peek());
            }
        }

        /// <summary>
        /// Can push ui without registed.
        /// </summary>
        public static void PushUiUnsafe(uint index, UIBase ui = null)
        {
            if (_sleeping)
                return;

            if (_uiStack.TryPeek(out var currentUI))
            {
                currentUI.ui?.Overlapped();
                OnOverlapped?.Invoke(currentUI);
            }

            _uiStack.Push(new(index, ui));

            OnPush?.Invoke(_uiStack.Peek());
        }

        public static void PopUI()
        {
            if (_sleeping)
                return;

            if (_uiStack.TryPop(out var currentUI))
            {
                currentUI.ui?.Pop();
                OnPop?.Invoke(currentUI);
            }

            if (_uiStack.TryPeek(out var nextUI))
            {
                nextUI.ui?.Return();
                OnReturn?.Invoke(nextUI);
            }
        }

        public static void PopTo(uint index)
        {
            if (_sleeping)
                return;

            while (_uiStack.TryPeek(out var currentUI))
            {
                if (currentUI.index == (uint)index)
                    break;

                PopUI();
            }
        }

        public static void RegisterUIs(IEnumerable<UIBase> uis)
        {
            foreach (var ui in uis)
                _uiDict.Add(ui.Index, ui);
        }

        public static UI Current() => _uiStack.TryPeek(out var ui) ? ui : _NoneUI;
        public static int Length() => _uiStack.Count;

        /// <summary>
        /// Temporary sleep handling before task complete.
        /// </summary>
        public static async UniTask SleepBefore(UniTask task)
        {
            _sleeping = true;
            await task;
            _sleeping = false;
        }

        public static async UniTask WaitUntilUiPop(uint index)
        {
            bool flag = false;
            Action<UI> action = ui => flag = ui.index == index;
            OnPop += action;
            await UniTask.WaitUntil(() => flag);
            OnPop -= action;
        }
    }
}