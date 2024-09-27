using Sirenix.OdinInspector;
using UnityEngine;
// ReSharper disable once CheckNamespace
namespace TCDebug.PackageSystems {
    /// <summary>
    /// A class to capture screenshots in Unity.
    /// </summary>
    public class TakeScreenShot : MonoBehaviour {
        [Tooltip("The file path where screenshots will be saved.")]
        [SerializeField, FolderPath] 
        string m_filePath = Application.dataPath;
        [Tooltip("Whether to use a key press to trigger the screenshot.")]
        public bool m_useKey = true;
        [Tooltip("The key used to capture the screenshot.")]
        [SerializeField] KeyCode m_screenshotKey = KeyCode.P;

        /// <summary>
        /// The main camera in the scene.
        /// </summary>
        Camera m_mainCamera;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        void Awake()
            => m_mainCamera = Camera.main;

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update() {
            if (m_useKey && Input.GetKeyDown(m_screenshotKey)) {
                CaptureScreenshot();
            }
        }

        /// <summary>
        /// Captures a screenshot and saves it to the specified file path.
        /// </summary>
        public void CaptureScreenshot() {
            if (m_mainCamera) {
                var fullFilePath = $"{m_filePath}/Screenshot_{System.DateTime.Now:yyyy-MM-dd-HH-mm-ss}.png";
                ScreenCapture.CaptureScreenshot(fullFilePath);
                Debug.Log("Screenshot captured: " + fullFilePath);
            }
            else {
                Debug.LogError("Main camera not found.");
            }
        }
    }
}