using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] protected float maxHealth = 10f;
        [SerializeField] protected UnityEvent onDamageTaken;
        protected float currentHealth = 10f;

        protected virtual void Awake()
        {
            MaximizeHealth();
        }

        protected virtual void MaximizeHealth()
        {
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(float amount)
        {
            currentHealth -= amount;
            onDamageTaken.Invoke();
            if (currentHealth <= 0)
                Death();
        }

        protected abstract void Death();
    }
}