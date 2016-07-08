using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareerManager.RectExtensions;
using KSPPluginFramework;
using UnityEngine;
using CareerManager;

namespace MissionList
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class _MissionList : MonoBehaviourExtended
    {

        // create window position object as a new rect value
        private static Rect _missionlistPosition = new Rect();
        /// create mission toggle value
        private bool _missionToggle = false;
        /// create add mission window draw value
        public static bool drawaddmission = false;

        internal override void Awake()
        {
            DontDestroyOnLoad(this);
        }

        internal override void Start()
        {
        }


        internal override void Update()
        {
            LogFormatted("" + drawaddmission);
        }

        internal override void LateUpdate()
        {
        }

        void OnGUI()
        {
            /// calls OnDraw method to draw GUI
            OnDraw();
        }

        private void OnDraw()
        {
            if (HighLogic.LoadedScene == GameScenes.EDITOR ||
                HighLogic.LoadedScene == GameScenes.FLIGHT ||
                HighLogic.LoadedScene == GameScenes.SPACECENTER ||
                HighLogic.LoadedScene == GameScenes.TRACKSTATION)
            {
                ///Debug.Log(HighLogic.LoadedScene);
                _missionlistPosition = GUILayout.Window(02, _missionlistPosition, OnWindow, "Mission List");

                if (_missionlistPosition.x == 0f && -_missionlistPosition.y == 0f)
                    _missionlistPosition = _missionlistPosition.CenterScreen();
            }
        }

        private void OnWindow(int windowId)
        {
            GUILayout.BeginVertical();
            foreach (String mission in _CareerManager.missionlist)
            {
                GUILayout.BeginVertical();
                GUILayout.BeginHorizontal();
                GUILayout.Label(mission);
                _missionToggle = GUILayout.Toggle(_missionToggle, "");
                GUILayout.EndHorizontal();
                GUILayout.Space(3f);
                GUILayout.BeginHorizontal();
                GUILayout.Label("Add:");
                GUILayout.Button("Contract");
                GUILayout.Button("Objective");
                GUILayout.Button("Ship");
                GUILayout.EndHorizontal();
                GUILayout.Space(3f);
                GUILayout.Label("Contracts:");
                GUILayout.Label("Objectives:");
                GUILayout.Label("Ships:");
                GUILayout.BeginHorizontal();
                GUILayout.Label("Advance: \u221A");
                GUILayout.Label("Cost: \u221A");
                GUILayout.Label("Profit: \u221A");
                GUILayout.EndHorizontal();
                GUILayout.Label("---------------------------------------------------------------------");
                GUILayout.Space(7f);
                GUILayout.EndVertical();
            }
            GUILayout.EndVertical();
            if (GUILayout.Button("Add Mission"))
            {
                drawaddmission = true;
                LogFormatted("on button press " + drawaddmission);
            }
            
            GUI.DragWindow();
        }

        internal override void OnDestroy()
        {
        }
    }








    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class _AddMissionWindow : _MissionList
    {
        // create window position object as a new rect value
        private static Rect _addmissionwindowPosition = new Rect();
        /// create string to show in add mission text box on first load
        private string addmissionstring = "Mission Name";
        /// temporary toggle value, will be removed when set up settings files for each mission
        private bool _missionToggle = false;


        internal override void Awake()
        {
            DontDestroyOnLoad(this);
            LogFormatted("AddMissionWindow is awake");

        }


        internal override void Update()
        {
            LogFormatted("" + _MissionList.drawaddmission);
        }

        void OnGUI()
        {
            {
                OnDrawAddMission();
            }
        }

        public void OnDrawAddMission()
        {
            ///LogFormatted("OnDrawAddMission = fired" + drawaddmission);
            if (_MissionList.drawaddmission)
            {
                LogFormatted("OnDrawAddMission = true & fired");
                _addmissionwindowPosition = GUILayout.Window(03, _addmissionwindowPosition, OnWindow, "New Mission");

                if (_addmissionwindowPosition.x == 0f && -_addmissionwindowPosition.y == 0f)
                    _addmissionwindowPosition = _addmissionwindowPosition.CenterScreen();
            }
        }

        public void OnWindow(int windowId)
        {
            addmissionstring = GUILayout.TextField(addmissionstring, 25);
            if (GUILayout.Button("Add Mission"))
            {
                _MissionList.drawaddmission = false;
                Debug.Log(addmissionstring);
                _CareerManager.missionlist.Add(addmissionstring);
                addmissionstring = "Mission Name";
            }


            GUI.DragWindow();
        }
    }

}
