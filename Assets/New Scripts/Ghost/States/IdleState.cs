using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HauntedIsland.Ghost
{
    public class IdleState : GhostState
    {
        private float idleDurationLeft;
        public IdleState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine)
        {
        }

        public override void OnEnterState(){
            ghostStateMachine.NavMeshAgent.isStopped = true;
            idleDurationLeft = ghostStateMachine.IdleDuration;
        }

        public override void Update()
        {
            idleDurationLeft -= Time.deltaTime;
            if(idleDurationLeft <= 0)
                ghostStateMachine.ChangeState(ghostStateMachine.PatrolState);
        }

        public override void OnExitState(){
            ghostStateMachine.NavMeshAgent.isStopped = false;
            idleDurationLeft = 0;
        }
    }
}
