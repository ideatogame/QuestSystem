using PlayerBehaviour;
using UnityEngine;

namespace QuestSystem.QuestRewards
{
    public class GoldReward : QuestReward
    {
        [SerializeField] private PlayerStats playerStats;

        public override string Name { get; protected set; } = "Gold";

        public override void GetReward()
        {
            if(playerStats != null)
                playerStats.AddGold((decimal)Quantity);
        }
    }
}