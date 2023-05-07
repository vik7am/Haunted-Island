using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace HauntedIsland
{

    public enum UIType{
        MAIN_MENU,
        HUD_MENU,
        PAUSE_MENU,
        GAME_OVER_MENU,
        GAME_WON_MENU
    }

    public class UIManager : GenericMonoSingleton<UIManager>
    {
        // HUD
        public GameObject HUDPanel;
        public TextMeshProUGUI titleGUI;
        public TextMeshProUGUI actionGUI;
        
        //MainMenu
        public GameObject mainMenuPanel;
        public Button startButton;
        public Button exitButton1;

        //PauseMenu
        public GameObject pauseMenuPanel;
        public Button resumeButton;
        public Button exitButton2;

        //GameOverMenu
        public GameObject gameOverPanel;
        public Button restartButton1;
        public Button exitButton3;

        //GameWonMenu
        public GameObject gameWonPanel;
        public Button restartButton2;
        public Button exitButton4;

        private GameObject activeUI;

        private void Start() {
            startButton.onClick.AddListener(StartGame);
            resumeButton.onClick.AddListener(ResumeGame);
            restartButton1.onClick.AddListener(RestartGame);
            restartButton2.onClick.AddListener(RestartGame);
            exitButton1.onClick.AddListener(ExitGame);
            exitButton2.onClick.AddListener(ExitGame);
            exitButton3.onClick.AddListener(ExitGame);
            exitButton4.onClick.AddListener(ExitGame);
            ShowUI(UIType.MAIN_MENU);
        }

        private void ExitGame(){
            Application.Quit();
        }

        private void RestartGame(){
            GameManager.Instance.RestartGame();
        }

        private void ResumeGame(){
            GameManager.Instance.ToogleGamePauseState();
            CloseActiveUI();
        }

        private void StartGame(){
            GameManager.Instance.StartGame();
        }

        public void ShowUI(UIType uIType){
            CloseActiveUI();
            Cursor.lockState = CursorLockMode.None;
            switch(uIType){
                case UIType.MAIN_MENU : activeUI = mainMenuPanel; break;
                case UIType.HUD_MENU : activeUI = HUDPanel; Cursor.lockState = CursorLockMode.Locked; break;
                case UIType.PAUSE_MENU : activeUI = pauseMenuPanel; Time.timeScale = 0; break;
                case UIType.GAME_OVER_MENU : activeUI = gameOverPanel; Time.timeScale = 0; break;
                case UIType.GAME_WON_MENU : activeUI = gameWonPanel; Time.timeScale = 0; break;
            }
            activeUI.SetActive(true);
        }

        public void CloseActiveUI(){
            if(activeUI){
                activeUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }

        public void SetHUDData(string title, string action){
            titleGUI.text = title;
            actionGUI.text = action;
        }
    }
}
