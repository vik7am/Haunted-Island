using UnityEngine;
using UnityEngine.UI;
using HauntedIsland.Manager;

namespace HauntedIsland.UI
{
    public class GameWonUI : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;

        private void Awake() {
            restartButton.onClick.AddListener(RestartGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void RestartGame(){
            GameManager.Instance.RestartGame();
        }

        private void ExitGame(){
            GameManager.Instance.ExitToMainMenu();
        }
    }
}
