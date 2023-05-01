using UnityEngine;

namespace HauntedIsland
{
    public class IdleState : BaseState
    {
        private float idleDuration;

        public IdleState(EnemyMovementStateMachine stateMachine) : base(stateMachine) {}

        public override void OnEnterState(){
            stateMachine.navmeshAgent.isStopped = true;
            this.idleDuration = stateMachine.idleDuration;
        }

        public override void Tick(){
            idleDuration -= Time.deltaTime;
            if(stateMachine.playerDetected){
                stateMachine.ChangeState(new ChaseState(stateMachine));
            }
            else if(idleDuration <= 0){
                stateMachine.ChangeState(new RoamState(stateMachine));
            }
        }
    }
}
