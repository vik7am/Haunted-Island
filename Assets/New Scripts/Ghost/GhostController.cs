using System;
using System.Collections;
using System.Collections.Generic;
using HauntedIsland.Player;
using UnityEngine;

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

        private void KillGhost(){
            Debug.Log("Ghost Killed");
            ghostStateMachine.ChangeState(ghostStateMachine.IdleState);
            ghostStateMachine.enabled = false;
            onGhostKilled?.Invoke();
        }

        
    }
}
