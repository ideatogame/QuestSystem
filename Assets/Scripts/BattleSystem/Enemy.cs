using System;

namespace BattleSystem
{
    public abstract class Enemy : Health
    {
        public static Action<Enemy> OnEnemyDeath = delegate {  };
        
        protected override void Death()
        {
            OnEnemyDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}