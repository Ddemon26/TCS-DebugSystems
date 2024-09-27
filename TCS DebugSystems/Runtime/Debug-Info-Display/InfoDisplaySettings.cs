using UnityEngine;
namespace TC._TestSystems
{
    [CreateAssetMenu(fileName = "Info Display Settings", menuName = "TCS/InfoDisplaySettings")]
    public class InfoDisplaySettings : ScriptableObject
    {
        [TextArea(5, 10)]
        public string m_infoDetails = "This is a new scriptable object script.";
    }
}
