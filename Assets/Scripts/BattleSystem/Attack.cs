using System.Collections.Generic;
using System.Linq;
using Miscellaneous;
using UnityEngine;

namespace BattleSystem
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float strength;
        [SerializeField] private LayerMask enemyLayer;

        private readonly Dictionary<GameObject, Health> selectedHealths = new Dictionary<GameObject, Health>();

        private void Awake()
        {
            Enemy.OnEnemyDeath += RemoveEnemy;
        }

        private void RemoveEnemy(Enemy enemy)
        {
            selectedHealths.Remove(enemy.gameObject);
        }

        private void Update()
        {
            bool attackInput = Input.GetKeyDown(KeyCode.K);

            if (!attackInput)
                return;

            for (int index = 0; index < selectedHealths.Count; index++)
                selectedHealths.Values.ToArray()[index].TakeDamage(strength);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareLayer(enemyLayer) || selectedHealths.ContainsKey(other.gameObject))
                return;
            
            selectedHealths.Add(other.gameObject, other.GetComponent<Health>());
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareLayer(enemyLayer) || !selectedHealths.ContainsKey(other.gameObject))
                return;

            selectedHealths.Remove(other.gameObject);
        }
    }
}