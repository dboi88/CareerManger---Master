﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CareerManager.RectExtensions;
using KSPPluginFramework;
using UnityEngine;
using CareerManager;
using KSP.IO;

namespace MissionList
{
    ///[KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class _MissionList : MonoBehaviourExtended
    {
        

        // create window position object as a new rect value
        private static Rect _missionlistPosition = new Rect();
        /// create mission toggle value
        private bool _missionToggle = false;
        /// create add mission window draw value
        public static bool drawaddmission = false;
        /// creae scroll view position for mission list
        public Vector2 scrollPosition;

        internal override void Awake()
        {
            /// comment out so that i can test saving settings on destroy
            ///DontDestroyOnLoad(this);
            PluginConfiguration config = PluginConfiguration.CreateForType<_MissionList>();
            config.load();
            _missionlistPosition = config.GetValue<Rect>("Mission List Position");
                {

            }
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
            if (!_CareerManager._hasInitStyles) _GUISkins.InitStyles();
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
                _missionlistPosition = GUILayout.Window(02, _missionlistPosition, OnWindow, "Mission List", _GUISkins._windowStyle);

                if (_missionlistPosition.x == 0f && -_missionlistPosition.y == 0f)
                    _missionlistPosition = _missionlistPosition.CenterScreen();
                 
            }
        }

        private void OnWindow(int windowId)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(340), GUILayout.Height(600));
            foreach (KeyValuePair<string, bool> pair in _CareerManager.missionviewlist)
            {
                GUILayout.BeginVertical();
                GUILayout.BeginHorizontal();
                GUILayout.Label(pair.Key, _GUISkins._missionnameStyle);
                if (GUILayout.Button("Show"))
                {
                    _CareerManager.missionviewlist[pair.Key] = true;
                    LogFormatted("Show" + pair.Key);
                }
                if (GUILayout.Button("Hide"))
                {
                    _CareerManager.missionviewlist[pair.Key] = false;
                    LogFormatted("Hide" + pair.Key);
                }
                if (GUILayout.Button("Delete Mission"))
                {
                    _CareerManager.missionviewlist.Remove(pair.Key);
                    LogFormatted("Delete Mission" + pair.Key);
                }
                GUILayout.EndHorizontal();
                GUILayout.Space(3f);
                GUILayout.EndVertical();
                if (pair.Value)
                {
                    GUILayout.BeginVertical();
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
                
            }
            GUILayout.EndScrollView();
            GUILayout.BeginVertical();
            if (GUILayout.Button("Add Mission"))
            {
                drawaddmission = true;
                LogFormatted("on button press " + drawaddmission);
            }
            GUILayout.EndVertical();

            GUI.DragWindow();
        }

        

        internal override void OnDestroy()
        {
            PluginConfiguration config = PluginConfiguration.CreateForType<_MissionList>();
            config.SetValue("Mission List Position", _missionlistPosition);
            config.save();
            LogFormatted("OnDestroy Triggered");
        }
    }








    ///[KSPAddon(KSPAddon.Startup.MainMenu, true)]
    ///not using this as this class is now started as a child of CareerManager
    public class _AddMissionWindow : _MissionList
    {
        // create window position object as a new rect value
        private static Rect _addmissionwindowPosition = new Rect();
        /// create string to show in add mission text box on first load
        private string addmissionstring = "Mission Name";

        internal override void Awake()
        {
            /// once sorted settings out i want to save on destroy so will remove this and reload at next scene, will also likely have GUI changes for different scenes
            DontDestroyOnLoad(this);
            LogFormatted("AddMissionWindow is awake");
        }


        void OnGUI()
        {
            /// call gui window code
            OnDrawAddMission();
        }

        /// <summary>
        /// GUI window code, creates window for GUI elements to sit in
        /// </summary>
        public void OnDrawAddMission()
        {
            ///LogFormatted("OnDrawAddMission = fired" + drawaddmission);
            if (_MissionList.drawaddmission)
            {
                LogFormatted("OnDrawAddMission = true & fired");
                _addmissionwindowPosition = GUILayout.Window(03, _addmissionwindowPosition, OnWindow, "New Mission", _GUISkins._windowStyle);

                if (_addmissionwindowPosition.x == 0f && -_addmissionwindowPosition.y == 0f)
                    _addmissionwindowPosition = _addmissionwindowPosition.CenterScreen();
            }
        }

        /// <summary>
        /// draw GUI elements within the created window from OnDrawAddMission()
        /// </summary>
        /// <param name="windowId"></param>
        public void OnWindow(int windowId)
        {
            /// create string input for new mission name
            addmissionstring = GUILayout.TextField(addmissionstring, 25);
            GUILayout.BeginHorizontal();
            /// create and if gui add mission button is pressed
            if (GUILayout.Button("Add Mission"))
            {
                /// change value to stop window being drawn
                drawaddmission = false;
                /// log mission name in debug
                LogFormatted("New Mission Created Named: " + addmissionstring);
                /// add string input to mission list
                _CareerManager.missionlist.Add(addmissionstring);
                /// add dictionary value including view toggle as true
                _CareerManager.missionviewlist.Add(addmissionstring, true);
                /// change string back to Mission Name ready for next input
                addmissionstring = "Mission Name";
            }
            if (GUILayout.Button("Cancel"))
            {
                /// change value to stop window being drawn
                drawaddmission = false;
                /// log mission name in debug
                LogFormatted("New Mission Creation Cancelled" + addmissionstring);
                /// change string back to Mission Name ready for next input
                addmissionstring = "Mission Name";
            }
            GUILayout.EndHorizontal();


            GUI.DragWindow();
        }
    }

}
