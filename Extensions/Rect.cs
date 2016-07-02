using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Return a rectangle centre screen position for a given size
/// </summary>
namespace CareerManager.RectExtensions
{
    public static class RectExtensions
    {
        public static Rect CenterScreen(this Rect thisRect)
        {
            ///Error checking if statement to ensure it doesn't devide by 0 (why a screen width or height would be zero i don't know but we are ready for this shit!)
            if (Screen.width > 0 && Screen.height > 0 && thisRect.width > 0f && thisRect.height > 0f)
            {
                thisRect.x = Screen.width / 2 - thisRect.width / 2;
                thisRect.y = Screen.height / 2 - thisRect.height / 2;
            }

            return thisRect;
        }
    }
}
