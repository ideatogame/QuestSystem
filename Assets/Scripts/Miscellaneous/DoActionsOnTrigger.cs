using UnityEngine;
using UnityEngine.Events;

namespace Miscellaneous
{
    public class DoActionsOnTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask triggerMask;
        [SerializeField] private UnityEvent onTriggerEnter;
        [SerializeField] private UnityEvent onTriggerExit;

        private void OnTriggerEnter(Collider other)
        {
            //if (!other.CompareLayer(triggerMask))
              //  return;
            
            onTriggerEnter.Invoke();
        }
        
        private void OnTriggerExit(Collider other)
        {
            //if (!other.CompareLayer(triggerMask))
             //   return;
            
            onTriggerExit.Invoke();
        }
    }
}