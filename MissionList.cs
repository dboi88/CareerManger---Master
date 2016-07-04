using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareerManager.RectExtensions;
using KSPPluginFramework;
using UnityEngine;

namespace MissionList
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class MissionList : MonoBehaviourExtended
    {

        // create window position object as a new rect value
        private static Rect _missionlistPosition = new Rect();
        /// create mission list
        public List<String> missionlist = new List<String>();
        /// create mission toggle value
        private bool _missionToggle = false;
        /// create add mission window draw value
        public bool drawaddmission = false;


        internal override void Awake()
        {
            DontDestroyOnLoad(this);
        }

        internal override void Start()
        {
        }



        internal override void Update()
        {
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
                Debug.Log(HighLogic.LoadedScene);
                _missionlistPosition = GUILayout.Window(02, _missionlistPosition, OnWindow, "Mission List");

                if (_missionlistPosition.x == 0f && -_missionlistPosition.y == 0f)
                    _missionlistPosition = _missionlistPosition.CenterScreen();
            }
        }

        private void OnWindow(int windowId)
        {
            GUILayout.BeginVertical();
            foreach (String mission in missionlist)
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
            }

            GUI.DragWindow();
        }

        internal override void OnDestroy()
        {
        }
    }








    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class AddMissionWindow : MissionList
    {
        // create window position object as a new rect value
        private static Rect _addmissionwindowPosition = new Rect();



        internal override void Awake()
        {
            DontDestroyOnLoad(this);
            LogFormatted("AddMissionWindow is awake");

        }

        internal override void Update()
        {
            
        }

        void OnGUI()
        {
            {
                LogFormatted("Mission draw admission = true");
                OnDrawAddMission();
            }
        }

        public void OnDrawAddMission()
        {
            LogFormatted("OnDrawAddMission = fired");
            if (drawaddmission == true)
            {
                LogFormatted("OnDrawAddMission = true & fired");
                _addmissionwindowPosition = GUILayout.Window(03, _addmissionwindowPosition, OnWindow, "Title");

                if (_addmissionwindowPosition.x == 0f && -_addmissionwindowPosition.y == 0f)
                    _addmissionwindowPosition = _addmissionwindowPosition.CenterScreen();
            }
        }

        private void OnWindow(int windowId)
        {
            GUI.DragWindow();
        }
    }

}
