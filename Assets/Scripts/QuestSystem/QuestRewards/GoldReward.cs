using PlayerBehaviour;
using UnityEngine;

namespace QuestSystem.QuestRewards
{
    public class GoldReward : QuestReward
    {
        [SerializeField] private PlayerStats playerStats;
        private bool isPlayerStatsNull;

        public override string Name { get; protected set; } = "Gold";

        private void Awake()
        {
            isPlayerStatsNull = playerStats == null;
            
            if (isPlayerStatsNull)
                playerStats = FindObjectOfType<PlayerStats>();
            
            isPlayerStatsNull = playerStats == null;
        }

        public override void GetReward()
        {
            if(!isPlayerStatsNull)
                playerStats.AddGold((decimal)Quantity);
        }
    }
}