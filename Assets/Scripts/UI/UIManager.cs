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

        private void Start() {
            HUDPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            startButton.onClick.AddListener(StartGame);
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

        public void SetHUDData(string title, string action){
            titleGUI.text = title;
            actionGUI.text = action;
        }
    }
}
