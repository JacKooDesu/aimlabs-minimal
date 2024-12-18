using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALM.Screens.Base
{
    public class ResolutionService
    {
        public void SetResolution(int width, int height, bool fullScreen)
        {
            Screen.SetResolution(width, height, fullScreen);
        }
    }
}
