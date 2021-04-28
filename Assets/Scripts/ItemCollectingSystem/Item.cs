using System;
using UnityEngine;

namespace ItemCollectingSystem
{
    public abstract class Item : MonoBehaviour
    {
        public static event Action<Item> OnItemCollected = delegate { };

        protected void OnTriggerEnter(Collider other)
        {
            PickItem();
        }

        protected virtual void PickItem()
        {
            OnItemCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}