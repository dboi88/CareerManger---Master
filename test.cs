namespace CareerManager
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class CareerManager : MonoBehaviourExtended
    {
        public MissionList missionInstance;
        public AddMissionWindow addmissionInstance;
  
        public void Start()
        {
            missionInstance = new MissionList();
            missionInstance.Start();
    
            addmissionInstance = new AddMissionWindow();
            addmissionInstance.Start();
    
        missionInstance.exList.add(addmissionInstance); // give the base class knowledge of the extended class. I've used a list since it sounds like something I'd use more than one of
    }
  
  public void OnGUI()
  {
    missionInstance.OnGUI();
    addmissionInstance.OnGUI();
  }
}
    

namespace MissionList
{
    
    public class MissionList : MonoBehaviourExtended
    {
      public bool drawaddmission = false;
      
      void OnGUI()
        {
            /// gui code that wraps the button
            if (GUILayout.Button("Add Mission"))
            {
                drawaddmission = true;
            }
        }
    }

    public class AddMissionWindow : MissionList
    {
      if (MissionList.drawaddmission)
            void OnGUI()
        {
         	if (MissionList.drawaddmission)
			{
            ///gui with a string input and wraps a button
			if (GUILayout.Button("Add Mission"))
            	{
               		MissionList.drawaddmission = false;
            	}
            }
        }
  }
