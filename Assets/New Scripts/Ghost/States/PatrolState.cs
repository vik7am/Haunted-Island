using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Ghost
{
    public class PatrolState : GhostState
    {
        private Bone bone;
        private Vector3 destination;

        public PatrolState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine)
        {
        }

        public override void OnEnterState(){
            bone = ghostStateMachine.GhostController.BoneManager.GetNextBone();
            bone.onBoneDestroyed += OnBoneDestroyed;
            destination = bone.transform.position;
            ghostStateMachine.NavMeshAgent.SetDestination(destination);
            ghostStateMachine.NavMeshAgent.isStopped = false;
        }

        private void OnBoneDestroyed(Bone bone){
            this.bone = ghostStateMachine.GhostController.BoneManager.GetNextBone();
        }

        public override void Update(){
            destination = bone.transform.position;
            ghostStateMachine.NavMeshAgent.SetDestination(destination);
            CheckDestination();
        }

        private void CheckDestination(){
            float distance = Vector3.Distance(ghostStateMachine.transform.position, destination);
            if(distance < ghostStateMachine.NavMeshAgent.stoppingDistance){
                ghostStateMachine.ChangeState(ghostStateMachine.IdleState);
            }
        }
    }
}
