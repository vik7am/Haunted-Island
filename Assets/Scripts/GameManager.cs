using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        [SerializeField] private FirstPersonCamera firstPersonCamera;
        private bool gamePaused;
        private int enemiesKilled;

        public void StartGame(){
            enemiesKilled = 0;
            SpawnManager.Instance.Spawn();
            firstPersonCamera.FollowPlayer(SpawnManager.Instance.GetPlayerTransForm());
            UIManager.Instance.SetMainMenuVisibility(false);
        }

        public void ResumeGame(){
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            gamePaused = !gamePaused;
        }

        public void PauseGame(){
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            gamePaused = !gamePaused;
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.P)){
                if(gamePaused)
                    ResumeGame();
                else
                    PauseGame();
                UIManager.Instance.SetPauseMenuVisibility(gamePaused);
            }
        }

        public void GameOver(){
            PauseGame();
            UIManager.Instance.SetGameOverMenuVisibility(true);
        }

        public void GameWon(){
            PauseGame();
            UIManager.Instance.SetHUDVisibility(false);
            UIManager.Instance.SetGameWonMenuVisibility(true);
        }

        public void EnemyKilled(){
            enemiesKilled++;
            if(enemiesKilled == SpawnManager.Instance.GetEnemyCount()){
                enemiesKilled = 0;
                GameWon();
            }
        }

        public void RestartGame(){
            Time.timeScale = 1;
            firstPersonCamera.DetachCamera();
            SpawnManager.Instance.Despawn();
            UIManager.Instance.SetGameOverMenuVisibility(false);
            UIManager.Instance.SetGameWonMenuVisibility(false);
            UIManager.Instance.SetMainMenuVisibility(true);
        }
    }
}
