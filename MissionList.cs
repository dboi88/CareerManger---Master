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

        protected bool Getdrawaddmission()
        {
            if (drawaddmission)
            {
                return true;
            }

            return false;
        }


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
                LogFormatted("on button press " + drawaddmission);
            }
            if (GUILayout.Button("make addmission window false"))
            {
                drawaddmission = false;
            }
            if (GUILayout.Button("make addmission window true"))
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
        /// create string to show in add mission text box on first load
        private string addmissionstring = "Mission Name";


        internal override void Awake()
        {
            DontDestroyOnLoad(this);
            LogFormatted("AddMissionWindow is awake");

        }


        internal override void Update()
        {
            LogFormatted("" + Getdrawaddmission());
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
            if (Getdrawaddmission())
            {
                LogFormatted("OnDrawAddMission = true & fired");
                _addmissionwindowPosition = GUILayout.Window(03, _addmissionwindowPosition, OnWindow, "Title");

                if (_addmissionwindowPosition.x == 0f && -_addmissionwindowPosition.y == 0f)
                    _addmissionwindowPosition = _addmissionwindowPosition.CenterScreen();
            }
        }

        public void OnWindow(int windowId)
        {
            addmissionstring = GUILayout.TextField(addmissionstring, 25);
            if (GUILayout.Button("Add Mission"))
            {
                drawaddmission = false;
                Debug.Log(addmissionstring);
                missionlist.Add(addmissionstring);
                addmissionstring = "Mission Name";
            }


            GUI.DragWindow();
        }
    }

}
