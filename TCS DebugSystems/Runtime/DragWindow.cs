using UnityEngine;
using UnityEngine.EventSystems;
namespace TCS.DebugSystems {
    /// <summary>
    /// A class that allows a UI window to be dragged within the bounds of its StackLabel canvas.
    /// </summary>
    public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler {
        [Tooltip("The RectTransform of the window to be dragged.")]
        [SerializeField] RectTransform m_dragRectTransform;
        
        [Tooltip("The Canvas in which the window is contained.")]
        [SerializeField] Canvas m_canvas;
        
        Vector2 m_canvasSize;
        
        void Awake() {
            EnsureRectTransformIsSet();
            FindCanvasInHierarchy();
            if (m_canvas) {
                m_canvasSize = m_canvas.GetComponent<RectTransform>().sizeDelta;
            }
        }

        /// <summary>
        /// Ensures that the RectTransform is set, assigning it from the StackLabel if not.
        /// </summary>
        void EnsureRectTransformIsSet() {
            if (!m_dragRectTransform) {
                m_dragRectTransform = transform.parent.GetComponent<RectTransform>();
            }
        }

        /// <summary>
        /// Finds the Canvas in the hierarchy, assigning it from the StackLabel if not set.
        /// </summary>
        void FindCanvasInHierarchy() {
            if (!m_canvas) {
                m_canvas = GetComponentInParent<Canvas>();
            }
        }

        /// <summary>
        /// Called when the object is dragged.
        /// </summary>
        /// <param name="eventData">Current event data.</param>
        public void OnDrag(PointerEventData eventData) {
            var newPosition = m_dragRectTransform.anchoredPosition + eventData.delta / m_canvas.scaleFactor;
            newPosition = ConstrainWithinCanvas(newPosition);
            m_dragRectTransform.anchoredPosition = newPosition;
        }

        /// <summary>
        /// Constrains the position within the bounds of the canvas.
        /// </summary>
        /// <param name="position">The new position to be constrained.</param>
        /// <returns>The constrained position.</returns>
        Vector2 ConstrainWithinCanvas(Vector2 position) {
            var minPosition = -0.5f * m_canvasSize;
            var maxPosition = 0.5f * m_canvasSize;

            // Define the threshold distances and the amount to pull back
            float leftThresholdDistance = 220f; // Example left threshold distance
            float rightThresholdDistance = 220f; // Example right threshold distance
            float bottomThresholdDistance = 80f; // Example bottom threshold distance
            float topThresholdDistance = 80f; // Example top threshold distance
            float pullBackAmount = 100f; // Example pull back amount

            // Calculate the distance from the center to the edges
            float distanceToLeftEdge = position.x - minPosition.x;
            float distanceToRightEdge = maxPosition.x - position.x;
            float distanceToBottomEdge = position.y - minPosition.y;
            float distanceToTopEdge = maxPosition.y - position.y;

            // Adjust position if it exceeds the threshold distance
            if (distanceToLeftEdge < leftThresholdDistance) {
                position.x += pullBackAmount * 2;
            }
            if (distanceToRightEdge < rightThresholdDistance) {
                position.x -= pullBackAmount * 2;
            }
            if (distanceToBottomEdge < bottomThresholdDistance) {
                position.y += pullBackAmount;
            }
            if (distanceToTopEdge < topThresholdDistance) {
                position.y -= pullBackAmount;
            }

            // Clamp the position within the canvas bounds
            position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);
            position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

            return position;
        }

        /// <summary>
        /// Called when a pointer down event is detected.
        /// </summary>
        /// <param name="eventData">Current event data.</param>
        public void OnPointerDown(PointerEventData eventData)
            => m_dragRectTransform.SetAsLastSibling();
    }
}