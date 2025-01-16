using System;
using UnityEngine.UI;

namespace ALM.Screens.Mission
{
    using ALM.Screens.Base.Setting;
    using UnityEngine;

    public class CrosshairService
    {
        readonly RawImage _crosshair;
        readonly GameplaySetting _gameplaySetting;
        readonly Texture _fallbackTex;

        public CrosshairService(
            RawImage crosshair,
            GameplaySetting gameplaySetting)
        {
            _crosshair = crosshair;
            _fallbackTex = _crosshair.texture;
            _gameplaySetting = gameplaySetting;

            _gameplaySetting.OnChange += CheckPath;

            UpdateCrosshair();

            void CheckPath(string s)
            {
                if (s == nameof(GameplaySetting.Crosshair))
                    UpdateCrosshair();
            }
        }

        void UpdateCrosshair()
        {
            _crosshair.texture = _gameplaySetting.GetCrosshairTexture() ?? _fallbackTex;
            _crosshair.SetNativeSize();
        }
    }
}