using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland
{
    public class GameManager : GenericMonoSingleton<GameManager>
    {
        [SerializeField] private FirstPersonCamera firstPersonCamera;

        public void StartGame(){
            SpawnManager.Instance.Spawn();
            firstPersonCamera.FollowPlayer(SpawnManager.Instance.GetPlayerTransForm());
            UIManager.Instance.SetMainMenuVisibility(false);
        }
    }
}
