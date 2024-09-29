using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable once CheckNamespace
namespace TCS.DebugSystems {
    public class ErrorDetectionUI : MonoBehaviour {
        [SerializeField] TextMeshProUGUI m_errorTextMesh;
        [SerializeField] Button m_closePanel;
        [SerializeField] Button m_copyError;
        
        [SerializeField] bool m_lockCursor;

        string m_lastError = string.Empty;

        void Awake() {
            m_closePanel.onClick.AddListener(Hide);
            m_closePanel.onClick.AddListener(UnpauseGame);
            m_copyError.onClick.AddListener(() => GUIUtility.systemCopyBuffer = m_errorTextMesh.text);
        }

        void Start() {
            Application.logMessageReceived += Application_logMessageReceived;
            Hide();
        }

        void Application_logMessageReceived(string condition, string stackTrace, LogType type) {
            if (type == LogType.Error || type == LogType.Exception) {
                string currentError = condition + "\n" + stackTrace;
                if (m_lastError != currentError) {
                    Show();
                    PauseGame();
                    m_errorTextMesh.text = "Error: " + condition + "\n" + stackTrace;
                    m_lastError = currentError;
                }
                // Optional: else clause for handling repeated errors
            }
        }

        void OnDestroy() {
            Application.logMessageReceived -= Application_logMessageReceived;
        }
        
        [Button]
        void LogError() {
            Debug.LogError("Test Error");
        }

        void Show() {
            gameObject.SetActive(true);
        }

        void Hide() {
            gameObject.SetActive(false);
        }

        static void UnlockCursor() {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        void LockCursor() {
            if (!m_lockCursor) return;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void PauseGame() {
            UnlockCursor();
            Time.timeScale = 0f;
        }
        void UnpauseGame() {
            LockCursor();
            Time.timeScale = 1f;
        }
    }
}