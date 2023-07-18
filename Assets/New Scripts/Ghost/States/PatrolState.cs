using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Ghost
{
    public class PatrolState : GhostState
    {
        private Vector3 destination;
        public PatrolState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine)
        {
        }

        public override void OnEnterState(){
            Debug.Log("patrol state entered");
            destination = ghostStateMachine.GhostController.BoneManager.GetNextBonePosition();
            ghostStateMachine.NavMeshAgent.SetDestination(destination);
            ghostStateMachine.NavMeshAgent.isStopped = false;
        }

        public override void Update(){
            float distance = Vector3.Distance(ghostStateMachine.transform.position, destination);
            Debug.Log(distance);
            if(distance < ghostStateMachine.NavMeshAgent.stoppingDistance){
                ghostStateMachine.ChangeState(ghostStateMachine.IdleState);
            }
        }
    }
}
