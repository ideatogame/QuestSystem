using System;

namespace QuestSystem
{
    public struct QuestInputSubject
    {
        public static event Action<Quest> OnQuestAccepted = delegate { };
        public static event Action<Quest> OnQuestAbandoned = delegate { };

        public static void AcceptQuest(Quest quest)
        {
            OnQuestAccepted?.Invoke(quest);
        }

        public static void AbandonQuest(Quest quest)
        {
            OnQuestAbandoned?.Invoke(quest);
        }
    }
}