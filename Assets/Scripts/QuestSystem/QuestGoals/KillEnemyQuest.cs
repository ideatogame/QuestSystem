using System;
using BattleSystem;
using UnityEngine;

namespace QuestSystem.QuestGoals
{
    public class KillEnemyQuest : QuestGoal
    {
        [SerializeField] private Enemy anyEnemyWithType;
        
        private Type enemyType;

        protected override void Awake()
        {
            base.Awake();
            Enemy.OnEnemyDeath += HandleEnemyDeath;
            enemyType = anyEnemyWithType.GetType();
        }

        private void HandleEnemyDeath(Enemy enemy)
        {
            if (enemy.GetType() != enemyType)
                return;
            
            SubtractRemaining(1f);
        }
    }
}