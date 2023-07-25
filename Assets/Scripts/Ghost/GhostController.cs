using System;
using UnityEngine;
using HauntedIsland.Player;

namespace HauntedIsland.Ghost
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField] private BoneManager boneManager;
        [SerializeField] private MeshRenderer ghostMeshRenderer;
        private GhostStateMachine ghostStateMachine;

        public BoneManager BoneManager => boneManager;
        
        public static event Action onGhostKilled;

        private void Awake() {
            ghostStateMachine = GetComponent<GhostStateMachine>();
            ToggleGhostVisibility(true);
        }
        
        private void OnEnable() {
            boneManager.onAllBonesDestroyed += KillGhost;
            LightManager.onDayNightChange += ToggleGhostVisibility;
        }

        private void OnDisable() {
            boneManager.onAllBonesDestroyed -= KillGhost;
            LightManager.onDayNightChange -= ToggleGhostVisibility;
        }

        private void ToggleGhostVisibility(bool isDay){
            ghostMeshRenderer.enabled = !isDay;
        }

        private void KillGhost(){
            ghostStateMachine.ChangeState(ghostStateMachine.IdleState);
            ghostStateMachine.enabled = false;
            onGhostKilled?.Invoke();
        }

        private void OnTriggerEnter(Collider other) {
            if(other.TryGetComponent<PlayerController>(out PlayerController player)){
                player.KillPlayer("Killed by Ghost");
            }
        }
    }
}
