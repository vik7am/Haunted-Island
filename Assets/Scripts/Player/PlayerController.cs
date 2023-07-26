using System;
using HauntedIsland.Manager;
using UnityEngine;

namespace HauntedIsland.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private FPSCamera fpsCamera;
        [SerializeField] private Transform playerHead;
        [SerializeField] private Light spotLight;
        [SerializeField] private float seaLevel;
        private PlayerMovement playerMovement;
        private Inventory inventory;
        private Camera _camera;

        public Inventory Inventory => inventory;
        public static event Action onPlayerKilled;

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

        private void Start() {
            AttachFPSCameraToHead();
            AttachSpotLightToFPSCamera();
        }

        private void Update() {
            CheckForDrowning();
        }

        private void AttachFPSCameraToHead(){
            fpsCamera.transform.SetParent(playerHead);
            fpsCamera.transform.localPosition = Vector3.zero;
            fpsCamera.SetPlayerTransform(transform);
        }

        private void AttachSpotLightToFPSCamera(){
            spotLight.transform.SetParent(fpsCamera.transform);
            spotLight.transform.localPosition = Vector3.zero;
        }

        private void ToggleSpotLight(bool isDay){
            spotLight.enabled = !isDay;
        }

        public void KillPlayer(string killMessage){
            playerMovement.SetMovementEnabled(false);
            GameManager.Instance.gameOverMessage = killMessage;
            onPlayerKilled?.Invoke();
        }

        private void CheckForDrowning(){
            if(transform.position.y < seaLevel){
                KillPlayer("You have Drowned");
            }
        }
    }
}
