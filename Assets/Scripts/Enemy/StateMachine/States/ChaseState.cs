using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland
{
    public class ChaseState : BaseState
    {
        private NavMeshAgent navmeshAgent;
        private float chaseRange;
        private Transform playerTransform;

        public ChaseState(EnemyMovementStateMachine stateMachine) : base(stateMachine) {
            navmeshAgent = stateMachine.navmeshAgent;
        }

        public override void OnEnterState(){
            playerTransform = stateMachine.playerTransform;
            chaseRange = stateMachine.chaseRange;
            stateMachine.navmeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(CheckChaseRange())
                navmeshAgent.SetDestination(playerTransform.position);
            else
                stateMachine.ChangeState(new IdleState(stateMachine));
        }

        private bool CheckChaseRange()
        {
            float distance = Vector3.Distance(stateMachine.transform.position, playerTransform.position);
            if(distance <=chaseRange)
                return true;
                stateMachine.PlayerOutOfRange();
            return false;
        }
    }
}
