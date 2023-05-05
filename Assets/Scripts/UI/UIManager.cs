using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace HauntedIsland
{
    public class UIManager : GenericMonoSingleton<UIManager>
    {
        // HUD
        public GameObject HUDPanel;
        public TextMeshProUGUI titleGUI;
        public TextMeshProUGUI actionGUI;
        
        //MainMenu
        public GameObject mainMenuPanel;
        public Button startButton;

        //PauseMenu
        public GameObject pauseMenuPanel;
        public Button resumeButton;

        //GameOverMenu
        public GameObject gameOverPanel;
        public Button restartButton1;

         //GameWonMenu
        public GameObject gameWonPanel;
        public Button restartButton2;

        private void Start() {
            HUDPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            startButton.onClick.AddListener(StartGame);
            resumeButton.onClick.AddListener(ResumeGame);
            restartButton1.onClick.AddListener(RestartGame);
            restartButton2.onClick.AddListener(RestartGame);
        }

        private void RestartGame(){
            GameManager.Instance.RestartGame();
        }

        private void ResumeGame(){
            GameManager.Instance.ResumeGame();
            SetPauseMenuVisibility(false);
        }

        private void StartGame(){
            GameManager.Instance.StartGame();
        }

        public void SetHUDVisibility(bool status){
            HUDPanel.SetActive(status);
        }

        public void SetMainMenuVisibility(bool status){
            mainMenuPanel.SetActive(status);
        }

        public void SetPauseMenuVisibility(bool status){
            pauseMenuPanel.SetActive(status);
        }

        public void SetGameOverMenuVisibility(bool status){
            gameOverPanel.SetActive(status);
        }

        public void SetGameWonMenuVisibility(bool status){
            gameWonPanel.SetActive(status);
        }

        public void SetHUDData(string title, string action){
            titleGUI.text = title;
            actionGUI.text = action;
        }
    }
}
