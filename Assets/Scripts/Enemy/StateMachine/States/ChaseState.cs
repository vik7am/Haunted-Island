using System;
using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland
{
    public class ChaseState : BaseState
    {
        private NavMeshAgent navmeshAgent;
        private float chaseRange;
        private Transform playerTransform;
        private float attackRange;

        public ChaseState(EnemyMovementStateMachine stateMachine) : base(stateMachine) {
            navmeshAgent = stateMachine.navmeshAgent;
        }

        public override void OnEnterState(){
            playerTransform = stateMachine.enemy.playerTransform;
            chaseRange = stateMachine.chaseRange;
            attackRange = stateMachine.attackRange;
            stateMachine.navmeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(CheckChaseRange())
                navmeshAgent.SetDestination(playerTransform.position);
            else
                stateMachine.ChangeState(new IdleState(stateMachine));
            if(CheckAttackRange())
                GameManager.Instance.GameOver();
                
        }

        private bool CheckAttackRange(){
            float distance = Vector3.Distance(stateMachine.transform.position, playerTransform.position);
            if(distance <= attackRange)
                return true;
            return false;
        }

        private bool CheckChaseRange()
        {
            float distance = Vector3.Distance(stateMachine.transform.position, playerTransform.position);
            if(distance <= chaseRange)
                return true;
                stateMachine.enemy.PlayerOutOfRange();
            return false;
        }
    }
}
