using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler
    {
        private Vector2 lastPosition;
        
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 difference = eventData.position - lastPosition;
            transform.position += difference;
            lastPosition = eventData.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            lastPosition = eventData.position;
        }
    }
}