using System;
using UnityEngine;
using HauntedIsland.Player;
using System.Collections;

namespace HauntedIsland.Ghost
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField] private BoneManager boneManager;
        [SerializeField] private MeshRenderer ghostMeshRenderer;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private float ghostEffectRange;
        [SerializeField] private float playerDetectionDelay;
        private GhostStateMachine ghostStateMachine;
        private bool isPlayerDetected;
        private bool isPlayerAlive;

        public BoneManager BoneManager => boneManager;
        public static event Action onGhostKilled;
        public static event Action<bool> onPlayerDetected;

        private void Awake() {
            ghostStateMachine = GetComponent<GhostStateMachine>();
            ToggleGhostVisibility(true);
        }

        private void Start() {
            isPlayerAlive = true;
            StartCoroutine(DetectPlayerWithDelay());
        }
        
        private void OnEnable() {
            boneManager.onAllBonesDestroyed += KillGhost;
            LightManager.onDayNightChange += ToggleGhostVisibility;
            PlayerController.onPlayerKilled += StopPlayerDetection;
        }

        private void OnDisable() {
            boneManager.onAllBonesDestroyed -= KillGhost;
            LightManager.onDayNightChange -= ToggleGhostVisibility;
            PlayerController.onPlayerKilled -= StopPlayerDetection;
        }

        private void KillGhost(){
            ghostStateMachine.ChangeState(ghostStateMachine.IdleState);
            ghostStateMachine.enabled = false;
            onGhostKilled?.Invoke();
        }

        private void ToggleGhostVisibility(bool isDay){
            ghostMeshRenderer.enabled = !isDay;
        }

        private void OnTriggerEnter(Collider other) {
            if(other.TryGetComponent<PlayerController>(out PlayerController player)){
                player.KillPlayer("Killed by Ghost");
            }
        }

        private void StopPlayerDetection(){
            isPlayerAlive = false;
        }

        private IEnumerator DetectPlayerWithDelay(){
            while(isPlayerAlive){
                DetectPlayer();
                yield return new WaitForSeconds(playerDetectionDelay);
            }
        }

        private void DetectPlayer(){
            Collider[] colliders = Physics.OverlapSphere(transform.position, ghostEffectRange, playerLayer, QueryTriggerInteraction.Collide);
            bool playerDetected = colliders.Length != 0;
            if(isPlayerDetected != playerDetected){
                isPlayerDetected = playerDetected;
                onPlayerDetected?.Invoke(playerDetected);
            }
        }
    }
}
