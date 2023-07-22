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
        [SerializeField] private LayerMask ghostLayer;
        [SerializeField] private Light spotLight;

        public static event Action onPlayerKilled;
        public static event Action<bool> onNearGhost;
        private bool isGhostNearby;

        private void Awake() {
            playerMovement = GetComponent<PlayerMovement>();
            inventory = GetComponent<Inventory>();
        }

        private void OnEnable() {
            LightManager.onEnableDarkMode += OnEnableDarkMode;
        }

        private void OnDisable() {
            LightManager.onEnableDarkMode -= OnEnableDarkMode;
        }

        private void OnEnableDarkMode(bool status){
            spotLight.enabled = status;
        }

        public void KillPlayer(){
            playerMovement.SetMovementEnabled(false);
            onPlayerKilled?.Invoke();
        }

        private void Update() {
            CheckForGhost();
        }

        private void CheckForGhost(){
            Collider[] colliders = Physics.OverlapSphere(transform.position, 7.0f, ghostLayer, QueryTriggerInteraction.Collide);
            foreach(Collider collider in colliders){
                if(collider.GetComponent<GhostController>()){
                    isGhostNearby = true;
                    onNearGhost?.Invoke(true);
                    return;
                }
            }
            if(isGhostNearby){
                isGhostNearby = false;
                onNearGhost?.Invoke(false);
            }
        }
    }
}
