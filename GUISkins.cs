using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CareerManager
{
    public class _GUISkins
    {
        /// create 2 GUI style objects to be defined in intiate styles method
        public static GUIStyle _windowStyle, _headingStyle, _labelStyle, _missionnameStyle, _linebreakStyle;

        public static void InitStyles()
        {
            /// set window style GUI value and a fixed width(keeps minmum window width at 250 pixels
            _windowStyle = new GUIStyle(HighLogic.Skin.window);
            _windowStyle.fixedWidth = 350f;

            /// set label style GUI value and a stretch width to stretch out to fit whatever text
            _labelStyle = new GUIStyle(HighLogic.Skin.window);
            _labelStyle.alignment = TextAnchor.MiddleCenter; ;
            _labelStyle.stretchWidth = true;
            _labelStyle.fontStyle = FontStyle.Bold;

            /// set label style GUI value and a stretch width to stretch out to fit whatever text
            _headingStyle = new GUIStyle();
            _headingStyle.alignment = TextAnchor.MiddleCenter; ;
            _headingStyle.stretchWidth = true;
            _headingStyle.fontStyle = FontStyle.Bold;
            _headingStyle.fontSize = 20;
            _headingStyle.fixedHeight = 15f;

            /// set label style GUI value and a stretch width to stretch out to fit whatever text
            _missionnameStyle = new GUIStyle();
            _missionnameStyle.alignment = TextAnchor.UpperLeft;
            _missionnameStyle.stretchWidth = true;
            _missionnameStyle.fontStyle = FontStyle.Bold;
            _missionnameStyle.fontSize = 20;
            _missionnameStyle.fixedHeight = 15f;

            /// set label style GUI value and a stretch width to stretch out to fit whatever text
            _linebreakStyle = new GUIStyle();
            _linebreakStyle.stretchWidth = true;
            _linebreakStyle.fixedHeight = 3f;

            /// set intiate styles check to true so only runs once
            _CareerManager._hasInitStyles = true;
        }
    }
}
