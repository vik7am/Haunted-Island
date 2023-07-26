using UnityEngine;
using UnityEngine.UI;
using HauntedIsland.Manager;

namespace HauntedIsland.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private GameObject settingPanel;
        [SerializeField] private Slider slider;
        [SerializeField] private Button saveButton;

        private void Awake() {
            startButton.onClick.AddListener(StartGame);
            exitButton.onClick.AddListener(ExitGame);
            settingButton.onClick.AddListener(GameSetting);
            saveButton.onClick.AddListener(SaveSettings);
        }

        private void StartGame(){
            GameManager.Instance.StartGame();
        }

        private void GameSetting(){
            settingPanel.SetActive(true);
            slider.value = GameManager.Instance.mouseSensitivity;
        }

        private void ExitGame(){
            GameManager.Instance.ExitGame();
        }

        private void SaveSettings(){
            settingPanel.SetActive(false);
            GameManager.Instance.mouseSensitivity = (int)slider.value;
        }
    }
}
