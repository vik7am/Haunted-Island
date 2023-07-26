using UnityEngine;
using UnityEngine.UI;
using HauntedIsland.Manager;
using TMPro;

namespace HauntedIsland.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private TextMeshProUGUI gameOverMessage;

        private void Awake() {
            restartButton.onClick.AddListener(RestartGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void OnEnable() {
            gameOverMessage.text = GameManager.Instance.gameOverMessage;
        }

        private void RestartGame(){
            GameManager.Instance.RestartGame();
        }

        private void ExitGame(){
            GameManager.Instance.ExitToMainMenu();
        }
    }
}
