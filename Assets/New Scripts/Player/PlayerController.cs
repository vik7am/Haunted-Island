using System;
using System.Collections;
using System.Collections.Generic;
using HauntedIsland.Ghost;
using UnityEngine;

namespace HauntedIsland.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private Inventory inventory;
        public Inventory Inventory => inventory;

        public static event Action onPlayerKilled;

        private void Awake() {
            playerMovement = GetComponent<PlayerMovement>();
            inventory = GetComponent<Inventory>();
        }

        public void KillPlayer(){
            playerMovement.SetMovementEnabled(false);
            onPlayerKilled?.Invoke();
        }

        // private void OnCollisionEnter(Collision other) {
        //     Debug.Log("collision");
        //     if(other.gameObject.GetComponent<GhostController>()){
        //         KillPlayer();
        //     }
        // }

        private void OnControllerColliderHit(ControllerColliderHit hit){
            Transform enemyTransform = hit.transform.parent;
            if(enemyTransform && enemyTransform.GetComponent<GhostController>()){
                Debug.Log("collision");
                KillPlayer();
            }
        }
    
    }
}
