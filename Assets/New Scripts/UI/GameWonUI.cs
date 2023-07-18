using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HauntedIsland
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
            Debug.Log("Restart Game");
        }

        private void ExitGame(){
            Debug.Log("Exit Game");
        }
    }
}
