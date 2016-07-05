    public class MissionList : MonoBehaviourExtended
    {
        public bool drawaddmission = false;
        void OnGUI()
        {
            OnDraw();
        }
        private void OnDraw()
        {
            /// some code
        }
        private void OnWindow(int windowId)
        {
            if (GUILayout.Button("Add Mission"))
            {
                drawaddmission = true;
                LogFormatted("on button press " + drawaddmission);
            }
            if (GUILayout.Button("make addmissionwindow false"))
            {
                drawaddmission = false;
            }

            GUI.DragWindow();
        }
    }
    public class AddMissionWindow : MissionList
    {
        private string addmissionstring = "Mission Name";   

        internal override void Update()
        {
            LogFormatted("" + drawaddmission);
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
            if (drawaddmission)
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
