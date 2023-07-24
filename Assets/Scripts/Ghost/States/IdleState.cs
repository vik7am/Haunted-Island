using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland.Ghost
{
    public class IdleState : GhostState
    {
        private float idleDurationLeft;
        private NavMeshAgent navMeshAgent;

        public IdleState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine){
            navMeshAgent = ghostStateMachine.NavMeshAgent;
        }

        public override void OnEnterState(){
            navMeshAgent.isStopped = true;
            idleDurationLeft = ghostStateMachine.IdleDuration;
        }

        public override void Update(){
            idleDurationLeft -= Time.deltaTime;
            if(idleDurationLeft <= 0)
                ghostStateMachine.ChangeState(ghostStateMachine.RoamState);
        }

        public override void OnExitState(){
            idleDurationLeft = 0;
        }
    }
}
