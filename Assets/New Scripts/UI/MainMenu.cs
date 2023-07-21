using System.Collections;
using System.Collections.Generic;
using HauntedIsland.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace HauntedIsland.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        private void Awake() {
            startButton.onClick.AddListener(StartGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void StartGame(){
            GameManager.Instance.StartGame();
        }

        private void ExitGame(){
            GameManager.Instance.ExitGame();
        }
    }
}
