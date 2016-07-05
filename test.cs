namespace MissionList
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class MissionList : MonoBehaviourExtended
    {
      public bool Drawaddmission
      {
      get
      {
          return drawaddmission;
      }
      set
      {
          drawaddmission = value;
      }
      public bool drawaddmission = false;
      
    }
    
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class AddMissionWindow : MissionList
    {
      if (Drawaddmission)
            {
            ///some code
            Drawadmission = false;
            }
  }
  /// provided by jimroberts
  change your MissionList class to this
public class MissionList : MonoBehaviourExtended
{
    public bool DrawAddMission = false
}
and your AddMissionWindow should allow you to use this
public class AddMissionWindow : MissionList
{
      if (DrawAddMission)
      {
            ///some code
            DrawAddMission = false;
      }
}
      
