using UnityEngine;

namespace HauntedIsland.Old
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        [SerializeField] private FirstPersonCamera firstPersonCamera;
        private bool gamePaused;
        private int enemiesKilled;
        [SerializeField] private Player player;
        public Player Player => player;

        public void StartGame(){
            enemiesKilled = 0;
            //SpawnManager.Instance.Spawn();
            player.gameObject.SetActive(true);
            firstPersonCamera.FollowPlayer(player.transform);
            //UIManager.Instance.ShowUI(UIType.MAIN_MENU);
        }

        public void ToogleGamePauseState(){
            if(gamePaused){
                gamePaused = false;
                UIManager.Instance.CloseActiveUI();
            }
            else{
                gamePaused = true;
                UIManager.Instance.ShowUI(UIType.PAUSE_MENU);
            }
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.P)){
                ToogleGamePauseState();
            }
        }

        public void GameOver(){
            UIManager.Instance.ShowUI(UIType.GAME_OVER_MENU);
        }

        public void GameWon(){
            UIManager.Instance.ShowUI(UIType.GAME_WON_MENU);
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
            UIManager.Instance.ShowUI(UIType.MAIN_MENU);
        }
    }
}
