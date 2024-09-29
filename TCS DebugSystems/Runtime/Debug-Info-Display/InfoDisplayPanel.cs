using UnityEngine;
using UnityEngine.UIElements;
using static TCS.DebugSystems.InfoDisplayPanelStrings;
namespace TCS.DebugSystems {
    public class InfoDisplayPanel : MonoBehaviour {
        UIDocument m_uiDocument;
        VisualElement m_root;

        ToggleButtonGroup m_toggleButtonGroup;
        ToggleButtonGroupState m_activeButton;


        Button m_closeButton;
        VisualElement m_mainPanel;

        Button m_openButton;
        VisualElement m_openDebugPanel;

        VisualElement m_switchPanel1;
        VisualElement m_panel1;

        VisualElement m_switchPanel2;
        VisualElement m_panel2;

        VisualElement m_switchPanel3;
        VisualElement m_panel3;

        const string HIDE_CONTAINER_CLASS = "container__hide";

        void Start() {
            m_uiDocument = GetComponent<UIDocument>();
            m_root = m_uiDocument.rootVisualElement;

            m_toggleButtonGroup = m_root.Q<ToggleButtonGroup>();
            m_toggleButtonGroup.RegisterValueChangedCallback
            (evt =>
            {
                m_activeButton = evt.newValue;
                SwitchContainer(m_activeButton);
            });

            m_closeButton = m_root.Q<Button>(CLOSE_BUTTON);
            m_closeButton.clicked += () => SetMainPanelVisibility(false);

            m_openButton = m_root.Q<Button>(OPEN_BUTTON);
            m_openButton.clicked += () => SetMainPanelVisibility(true);

            m_mainPanel = m_root.Q<VisualElement>(MAIN_PANEL);

            m_openDebugPanel = m_root.Q<VisualElement>(OPEN_DEBUG_PANEL);

            m_switchPanel1 = m_root.Q<VisualElement>(SWITCH_PANEL_1);
            m_panel1 = m_switchPanel1.Q<VisualElement>(PANEL_1);

            m_switchPanel2 = m_root.Q<VisualElement>(SWITCH_PANEL_2);
            m_panel2 = m_switchPanel2.Q<VisualElement>(PANEL_2);

            m_switchPanel3 = m_root.Q<VisualElement>(SWITCH_PANEL_3);
            m_panel3 = m_switchPanel3.Q<VisualElement>(PANEL_3);

            SetEnabled(m_switchPanel1, m_toggleButtonGroup.value[0]);
            SetEnabled(m_switchPanel2, m_toggleButtonGroup.value[1]);
            SetEnabled(m_switchPanel3, m_toggleButtonGroup.value[2]);
        }

        void SwitchContainer(ToggleButtonGroupState activeButton) {
            SetEnabled(m_switchPanel1, activeButton[0]);
            SetEnabled(m_switchPanel2, activeButton[1]);
            SetEnabled(m_switchPanel3, activeButton[2]);
        }

        void SetMainPanelVisibility(bool isVisible) {
            if (isVisible) {
                m_mainPanel.RemoveFromClassList(HIDE_CONTAINER_CLASS);
                m_openDebugPanel.AddToClassList(HIDE_CONTAINER_CLASS);
            }
            else {
                m_mainPanel.AddToClassList(HIDE_CONTAINER_CLASS);
                m_openDebugPanel.RemoveFromClassList(HIDE_CONTAINER_CLASS);
            }
        }

        static void SetEnabled(VisualElement element, bool isEnabled) {
            if (isEnabled) {
                element.RemoveFromClassList(HIDE_CONTAINER_CLASS);
            }
            else {
                element.AddToClassList(HIDE_CONTAINER_CLASS);
            }
        }
    }
}