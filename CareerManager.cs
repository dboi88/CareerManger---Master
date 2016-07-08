using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KSPPluginFramework;
using UnityEngine;
using KSP;

namespace CareerManager
{
    /// <summary>
    /// launch the main plug in code here using KSP addon, everying else should be a child of this
    /// </summary>
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class _CareerManager : MonoBehaviourExtended
    {
        /// create mission list
        public static List<String> missionlist = new List<String>();
        /// create boolian to record if styles have been set or not and set false to start
        public static bool _hasInitStyles = false;
        
        
        

        internal override void Update()
        {
        }

        internal override void Awake()
        {
            LogFormatted("Parent is awake - Career Manager");

            /// create mission list GUI as child
            var _Child_MissionList = gameObject.AddComponent<MissionList._MissionList>();
            LogFormatted("_Child_MissionList created");
            /// create add mission GUI as child
            var _Child_AddMissionWindow = gameObject.AddComponent<MissionList._AddMissionWindow>();
            LogFormatted("_Child_AddMissionWindow created");

            //Create a Child Object
            MBExtendedChild Child = gameObject.AddComponent<MBExtendedChild>();

            //Start the repeating worker to fire once each second
            StartRepeatingWorker(1);
            DontDestroyOnLoad(this);
        }



        private Int32 intCounter=0;
        internal override void RepeatingWorker()
        {
            System.Threading.Thread.Sleep(intCounter);
            //increment the counter
            intCounter += 1;
            if (intCounter>9)
            {
                //Stop the function after ten seconds
                StopRepeatingWorker();
            }
            LogFormatted("Last RepeatFunction Ran for: {0}ms",RepeatingWorkerDuration.TotalMilliseconds);
            LogFormatted("UT Since Last RepeatFunction: {0}",RepeatingWorkerUTPeriod);
        }
    }

    public class MBExtendedChild : MonoBehaviourExtended
    {
        internal override void Awake()
        {
            LogFormatted("Child is awake");
        }
    }
}
