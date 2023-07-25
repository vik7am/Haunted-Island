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
            LightManager.onDayNightChange += ToggleSpotLight;
        }

        private void OnDisable() {
            LightManager.onDayNightChange -= ToggleSpotLight;
        }

        private void ToggleSpotLight(bool isDay){
            spotLight.enabled = !isDay;
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
            bool ghostFound = Array.Exists(colliders, collider => collider.GetComponent<GhostController>() != null);
            if(isGhostNearby != ghostFound){
                isGhostNearby = ghostFound;
                onNearGhost?.Invoke(isGhostNearby);
            }
        }
    }
}
