using System;
using System.Collections;
using UnityEngine;

namespace PlayerBehaviour
{
    public class PlayerStats : MonoBehaviour
    {
        public static event Action<PlayerStats> OnStatsChanged = delegate {  };
        
        public int Level { get; private set; } = 1;
        public float Xp { get; private set; }
        public decimal Gold { get; private set; }
        public float NextLevelXp => nextLevelXp;
        
        [SerializeField] private float nextLevelXp = 100f;
        [SerializeField] private float difficultyFactor = 1.5f;

        private void Start()
        {
#if !UNITY_WEBGL
            Level = PlayerPrefs.GetInt("PlayerLevel", Level);
            Xp = PlayerPrefs.GetFloat("PlayerXP");
            Gold = (decimal)PlayerPrefs.GetFloat("PlayerGold");
            nextLevelXp = PlayerPrefs.GetFloat("PlayerNextLevelXP", nextLevelXp);
#endif
            StartCoroutine(LateStart(0.01f));
        }

#if UNITY_EDITOR
        private void Update()
        {
            if(!Input.GetKeyDown(KeyCode.R))
                return;
            
            PlayerPrefs.DeleteAll();
            
            Level = PlayerPrefs.GetInt("PlayerLevel", 1);
            Xp = PlayerPrefs.GetFloat("PlayerXP", 0f);
            Gold = (decimal)PlayerPrefs.GetFloat("PlayerGold", 0f);
            nextLevelXp = PlayerPrefs.GetFloat("PlayerNextLevelXP", 100f);
            
            OnStatsChanged?.Invoke(this);
        }
#endif

#if !UNITY_WEBGL
        private void OnDestroy()
        {
            PlayerPrefs.SetInt("PlayerLevel", Level);
            PlayerPrefs.SetFloat("PlayerXP", Xp);
            PlayerPrefs.SetFloat("PlayerGold", (float)Gold);
            PlayerPrefs.SetFloat("PlayerNextLevelXP", nextLevelXp);
        }
#endif
        
        private IEnumerator LateStart(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            OnStatsChanged?.Invoke(this);
        }

        public void AddXp(float amount)
        {
            Xp += amount;
            
            if (Xp >= nextLevelXp)
            {
                Xp -= nextLevelXp;
                nextLevelXp *= difficultyFactor;
                Level++;
            }
            
            OnStatsChanged?.Invoke(this);
        }

        public void AddGold(decimal amount)
        {
            Gold += amount;
            OnStatsChanged?.Invoke(this);
        }
    }
}