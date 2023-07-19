using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Ghost
{
    public class PatrolState : GhostState
    {
        private Transform boneTransform;
        private Vector3 destination;
        public PatrolState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine)
        {
        }

        public override void OnEnterState(){
            boneTransform = ghostStateMachine.GhostController.BoneManager.GetNextBoneTransform();
            destination = boneTransform.position;
            ghostStateMachine.NavMeshAgent.SetDestination(destination);
            ghostStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void Update(){
            destination = boneTransform.position;
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
