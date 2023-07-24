using UnityEngine;
using UnityEngine.SceneManagement;

namespace HauntedIsland.Manager
{
    public enum Level {MAIN_MENU, GAME_WORLD}

    public class GameManager : GenericMonoSingleton<GameManager>
    {

        public void RestartGame(){
            StartGame();
        }

        public void StartGame(){
            SceneManager.LoadScene((int)Level.GAME_WORLD);
        }

        public void ExitToMainMenu(){
            SceneManager.LoadScene((int)Level.MAIN_MENU);
        }

        public void ExitGame(){
            Application.Quit();
        }
    }
}
