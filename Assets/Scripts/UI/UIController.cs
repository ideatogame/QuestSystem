using PlayerBehaviour;
using QuestSystem;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private StatsUI statsUI;
        [SerializeField] private NewQuestUI newQuestUI;
        [SerializeField] private QuestListUI questListUI;
        
        private void Awake()
        {
            if (statsUI != null)
                PlayerStats.OnStatsChanged += HandleStatsChanged;

            if (newQuestUI != null)
                NewQuest.OnQuestSelection += HandleQuestSelection;

            if (questListUI != null)
            {
                PlayerQuests.OnNewQuestAdded += HandleQuestAdded;
                QuestInputSubject.OnQuestAbandoned += HandleAbandonButtonPressed;
            }
        }

        private void OnDestroy()
        {
            if (statsUI != null)
                PlayerStats.OnStatsChanged -= HandleStatsChanged;
            
            if (newQuestUI != null)
                NewQuest.OnQuestSelection -= HandleQuestSelection;
            
            if (questListUI != null)
            {
                PlayerQuests.OnNewQuestAdded -= HandleQuestAdded;
                QuestInputSubject.OnQuestAbandoned -= HandleAbandonButtonPressed;
            }
        }
        
        private void HandleAbandonButtonPressed(Quest quest)
        {
            questListUI.RemoveQuest(quest);
        }
        
        private void HandleQuestAdded(Quest quest)
        {
            questListUI.AddQuest(quest);
        }
        
        private void HandleQuestSelection(Quest quest)
        {
            newQuestUI.Bind(quest);
        }

        private void HandleStatsChanged(PlayerStats stats)
        {
            statsUI.Bind(stats);
        }
    }
}