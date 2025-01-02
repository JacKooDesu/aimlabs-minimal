using System;

namespace ALM.Screens.Base
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class HandlabeSceneAttribute : System.Attribute
    {
        readonly string _sceneName;
        public string SceneName => _sceneName;

        public HandlabeSceneAttribute(string sceneName)
        {
            this._sceneName = sceneName;
        }
    }
}