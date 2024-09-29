using UnityEngine;
namespace TCS.DebugSystems
{
    [CreateAssetMenu(fileName = "Info Display Settings", menuName = "TCS/InfoDisplaySettings")]
    public class InfoDisplaySettings : ScriptableObject
    {
        [TextArea(5, 10)]
        public string m_infoDetails = "This is a new scriptable object script.";
    }
}
