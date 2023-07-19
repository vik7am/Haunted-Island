using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("Restart Game");
        }

        private void ExitGame(){
            Debug.Log("Exit Game");
        }
    }
}
