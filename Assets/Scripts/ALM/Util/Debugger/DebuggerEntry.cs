using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ALM.Util.Debugger
{
    public class DebuggerEntry : MonoBehaviour
    {
        public static bool IsDebugMode { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        static void _Entry()
        {
#if !UNITY_EDITOR
            var args = Environment.GetCommandLineArgs();
            if (!args.Contains("-debugger"))
                return;
#endif
            IsDebugMode = true;

            var go = new GameObject("DebuggerEntry");
            var entry = go.AddComponent<DebuggerEntry>();
            DontDestroyOnLoad(go);

            Application.logMessageReceived += entry.LogCallBack;
        }

        const float NATIVE_WIDTH = 960;
        const float NATIVE_HEIGHT = 540;

        const float WINDOW_WIDTH = 600;
        const float WINDOW_HEIGHT = 400;
        const float WINDOW_WIDTH_HIDE = 100;
        const float WINDOW_HEIGHT_HIDE = 50;

        Rect _windowRect = new(10, 10, WINDOW_WIDTH, WINDOW_HEIGHT);
        Vector2 _scrollPos = default;
        bool _isShow = false;
        int _currentExpandIndex = -1;
        (bool Info, bool Warning, bool Error) _msgFilter = (true, true, true);

        readonly GUILayoutOption _toggleLayougOption = GUILayout.Width(50);

        Queue<Log> _logs = new();
        void OnGUI()
        {
            Vector3 scale = new Vector3(Screen.width / NATIVE_WIDTH, Screen.height / NATIVE_HEIGHT, 1.0f);
            GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, scale);

            _windowRect = GUI.Window(0, _windowRect, WindowFunc, "Debugger");
        }

        void WindowFunc(int id)
        {

            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Button(_isShow ? "Hide" : "Open"))
                    _isShow = !_isShow;

                if (_isShow && GUILayout.Button("Clear"))
                    _logs.Clear();

                var style = GUI.skin.button;
                if (_isShow)
                    _msgFilter =
                    (
                        GUILayout.Toggle(_msgFilter.Info, "<color=white>●</color>", style, _toggleLayougOption),
                        GUILayout.Toggle(_msgFilter.Warning, "<color=yellow>●</color>", style, _toggleLayougOption),
                        GUILayout.Toggle(_msgFilter.Error, "<color=red>●</color>", style, _toggleLayougOption)
                    );
            }
            GUILayout.EndHorizontal();

            if (!_isShow)
            {
                _windowRect.width = WINDOW_WIDTH_HIDE;
                _windowRect.height = WINDOW_HEIGHT_HIDE;
                GUI.DragWindow(new Rect(0, 0, 10000, 20));
                return;
            }
            else
            {
                _windowRect.width = WINDOW_WIDTH;
                _windowRect.height = WINDOW_HEIGHT;
            }

            _scrollPos = GUILayout.BeginScrollView(_scrollPos);
            {
                var iter = 0;

                foreach (var log in _logs)
                {
                    DrawLog(log, iter);
                    iter++;
                }
            }
            GUILayout.EndScrollView();

            GUI.DragWindow(new Rect(0, 0, 10000, 20));
        }

        void DrawLog(Log log, int iter)
        {
            if ((log is Error && !_msgFilter.Error) ||
                (log is Warning && !_msgFilter.Warning) ||
                (log is Info && !_msgFilter.Info))
                return;

            GUILayout.BeginHorizontal();
            {
                var color = log switch
                {
                    Error => "red",
                    Warning => "yellow",
                    Info => "white",
                    _ => "white"
                };
                if (GUILayout.Button($"<color={color}>●</color>", GUILayout.Width(20)))
                    _currentExpandIndex = _currentExpandIndex == iter ? -1 : iter;

                GUILayout.TextArea(log.Msg);
            }
            GUILayout.EndHorizontal();

            if (_currentExpandIndex == iter)
                GUILayout.TextArea(log.Trace);
        }

        void LogCallBack(string condition, string stackTrace, LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                case LogType.Exception:
                case LogType.Assert:
                    _logs.Enqueue(new Error(condition, stackTrace));
                    break;
                case LogType.Warning:
                    _logs.Enqueue(new Warning(condition, stackTrace));
                    break;
                case LogType.Log:
                    _logs.Enqueue(new Info(condition, stackTrace));
                    break;
            }

            if (_logs.Count > 100)
            {
                _logs.Dequeue();
                _currentExpandIndex--;
            }
        }

        abstract record Log(string Msg, string Trace);
        record Error(string Msg, string Trace) : Log(Msg, Trace);
        record Warning(string Msg, string Trace) : Log(Msg, Trace);
        record Info(string Msg, string Trace) : Log(Msg, Trace);
    }
}
