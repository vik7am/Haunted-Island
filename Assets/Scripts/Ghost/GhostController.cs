using System;
using UnityEngine;
using HauntedIsland.Player;

namespace HauntedIsland.Ghost
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField] private BoneManager boneManager;
        private GhostStateMachine ghostStateMachine;

        public BoneManager BoneManager => boneManager;
        public static event Action onGhostKilled;

        private void Awake() {
            ghostStateMachine = GetComponent<GhostStateMachine>();
        }
        
        private void OnEnable() {
            boneManager.onAllBonesDestroyed += KillGhost;
        }

        private void OnDisable() {
            boneManager.onAllBonesDestroyed -= KillGhost;
        }

        private void KillGhost(){
            ghostStateMachine.ChangeState(ghostStateMachine.IdleState);
            ghostStateMachine.enabled = false;
            onGhostKilled?.Invoke();
        }

        private void OnTriggerEnter(Collider other) {
            if(other.TryGetComponent<PlayerController>(out PlayerController player)){
                player.KillPlayer();
            }
        }
    }
}
