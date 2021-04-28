using PlayerBehaviour;
using UnityEngine;

namespace ItemCollectingSystem.Items
{
    public class XpOrb : Item
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private float xpAmount = 10f;

        private void Awake()
        {
            if (playerStats == null)
                playerStats = FindObjectOfType<PlayerStats>();
        }

        protected override void PickItem()
        {
            base.PickItem();
            playerStats.AddXp(xpAmount);
        }
    }
}