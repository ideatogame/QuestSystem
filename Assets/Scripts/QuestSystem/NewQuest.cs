using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace QuestSystem
{
    public class NewQuest : MonoBehaviour
    {
        public static event Action<Quest> OnQuestSelection = delegate {  };
        public static event Action<bool> OnNewQuestWindowStateChanged = delegate {  };

        [Header("Parameters")]
        [SerializeField] private string questName;
        [SerializeField] private string questDescription;
        
        [Header("Events")]
        [SerializeField] private UnityEvent onQuestDisabled;
        [SerializeField] private UnityEvent onQuestEnabled;
        
        private Quest newQuest;
        private bool questAvailable;

        private void OnEnable()
        {
            QuestInputSubject.OnQuestAbandoned += RegenerateOnAbandon;
            GenerateQuest();
        }

        private void OnDisable()
        {
            QuestInputSubject.OnQuestAbandoned -= RegenerateOnAbandon;
        }
        
        public void SelectNewQuest()
        {
            if(!questAvailable)
                return;
            
            OnQuestSelection?.Invoke(newQuest);
            OnNewQuestWindowStateChanged?.Invoke(true);
        }

        public void UnselectNewQuest()
        {
            if(!questAvailable)
                return;
            
            OnNewQuestWindowStateChanged?.Invoke(false);
        }
        
        private void RegenerateOnAbandon(Quest quest)
        {
            if (quest != newQuest || newQuest == null)
                return;
            
            newQuest.DisableQuest();
            GenerateQuest();
        }

        private void GenerateQuest()
        {
            List<QuestGoal> goals = GetComponentsInChildren<QuestGoal>().ToList();
            List<QuestReward> rewards = GetComponentsInChildren<QuestReward>().ToList();
            
            newQuest = new Quest(questName, questDescription, goals, rewards);
            questAvailable = true;
            onQuestEnabled.Invoke();
            
            QuestInputSubject.OnQuestAccepted += DisableQuest;
        }

        private void DisableQuest(Quest quest)
        {
            if (quest != newQuest)
                return;
            
            QuestInputSubject.OnQuestAccepted -= DisableQuest;
            questAvailable = false;
            onQuestDisabled.Invoke();
        }

    }
}