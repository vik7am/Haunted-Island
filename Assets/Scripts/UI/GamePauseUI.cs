using HauntedIsland.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace HauntedIsland.UI
{
    public class GamePauseUI : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button exitButton;
        private UIManager uiManager;

        private void Awake() {
            resumeButton.onClick.AddListener(RestartGame);
            exitButton.onClick.AddListener(ExitGame);
            uiManager = transform.parent.GetComponent<UIManager>();
        }

        private void RestartGame(){
            uiManager.ResumeGame();
        }

        private void ExitGame(){
            GameManager.Instance.ExitToMainMenu();
        }
    }
}
