using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LoadUI : MonoBehaviour
    {
        [SerializeField] private int uiSceneBuildIndex;

        private void Start()
        {
            SceneManager.LoadScene(uiSceneBuildIndex, LoadSceneMode.Additive);
        }
    }
}