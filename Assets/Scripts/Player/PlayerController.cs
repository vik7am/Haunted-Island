using System;
using HauntedIsland.Ghost;
using HauntedIsland.Manager;
using UnityEngine;

namespace HauntedIsland.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Light spotLight;
        [SerializeField] private LayerMask ghostLayer;
        [SerializeField] private float ghostRange;
        [SerializeField] private float seaLevel;
        private PlayerMovement playerMovement;
        private Inventory inventory;
        private bool isGhostNearby;

        public Inventory Inventory => inventory;

        public static event Action onPlayerKilled;
        public static event Action<bool> onNearGhost;

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

        public void KillPlayer(string killMessage){
            playerMovement.SetMovementEnabled(false);
            GameManager.Instance.gameOverMessage = killMessage;
            onPlayerKilled?.Invoke();
        }

        private void Update() {
            CheckForGhost();
            CheckForDrowning();
        }

        private void CheckForDrowning(){
            if(transform.position.y < seaLevel){
                KillPlayer("You have Drowned");
            }
        }

        private void CheckForGhost(){
            Collider[] colliders = Physics.OverlapSphere(transform.position, ghostRange, ghostLayer, QueryTriggerInteraction.Collide);
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
