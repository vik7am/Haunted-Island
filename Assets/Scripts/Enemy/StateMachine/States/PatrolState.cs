using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland.Old
{
    public class PatrolState : BaseState
    {
        private NavMeshAgent navmeshAgent;
        private float chaseRange;
        private float attackRange;
        private BoneManager boneManager;
        private Vector3 destination;

        public PatrolState(EnemyMovementStateMachine stateMachine) : base(stateMachine) {
            navmeshAgent = stateMachine.navmeshAgent;
            boneManager = stateMachine.Enemy.BoneManager;
        }

        public override void OnEnterState(){
            destination = boneManager.GetNextBonePosition();
            navmeshAgent.SetDestination(destination);
        }

        public override void Tick()
        {
            float distance = Vector3.Distance(stateMachine.transform.position, destination);
            if(distance < navmeshAgent.stoppingDistance){
                stateMachine.ChangeState(new IdleState(stateMachine));
            }
        }
    }
}
