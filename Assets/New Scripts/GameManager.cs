using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HauntedIsland.Manager
{
    public enum Level {MAIN_MENU, GAME_WORLD}

    public class GameManager : GenericMonoSingleton<GameManager>
    {
        public void RestartGame(){
            SceneManager.LoadScene((int)Level.GAME_WORLD);
        }
    }
}
