using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareerManager.RectExtensions;
using KSPPluginFramework;
using UnityEngine;

namespace MissionList
{
    [KSPAddon(KSPAddon.Startup.MainMenu,true)]
    public class WindowTemplate : MonoBehaviourExtended
    {
        // create window position object as a new rect value
        private static Rect _mainwindowPosition = new Rect();

        internal override void Awake()
        {
            DontDestroyOnLoad(this);

        }

        internal override void Update()
        {
        }

        void OnGUI()
        {
        OnDraw();
        }

        private void OnDraw()
        {
            _mainwindowPosition = GUILayout.Window(01, _mainwindowPosition, OnWindow, "Title");

            if (_mainwindowPosition.x == 0f && -_mainwindowPosition.y == 0f)
                _mainwindowPosition = _mainwindowPosition.CenterScreen();
        }

        private void OnWindow(int windowId)
        {
            GUI.DragWindow();
        }
    }
}
