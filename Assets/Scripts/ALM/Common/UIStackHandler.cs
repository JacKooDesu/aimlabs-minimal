using System;
using System.Collections.Generic;
using ALM.Screens.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ALM.Common
{
    public static class UIStackHandler
    {
        public record UI(uint index, UIBase ui);
        static Stack<UI> _uiStack = new();
        static Dictionary<uint, UIBase> _uiDict = new();

        [RuntimeInitializeOnLoadMethod]
        public static void Initialize()
        {
            SceneManager.sceneUnloaded += _ => Reset();
        }

        public static void Reset()
        {

        }

        public static void PushUI(uint index)
        {
            if (_uiStack.TryPeek(out var currentUI))
                currentUI.ui.Overlapped();

            if (_uiDict.TryGetValue((uint)index, out var nextUI))
            {
                nextUI.Push();
                _uiStack.Push(new((uint)index, nextUI));
            }
        }

        public static void PopUI()
        {
            if (_uiStack.TryPop(out var currentUI))
                currentUI.ui.Pop();

            if (_uiStack.TryPeek(out var nextUI))
                nextUI.ui.Return();
        }

        public static void PopTo(uint index)
        {
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
    }
}