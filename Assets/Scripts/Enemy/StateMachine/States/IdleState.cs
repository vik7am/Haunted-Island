using UnityEngine;

namespace HauntedIsland
{
    public class IdleState : BaseState
    {
        private float idleDuration;

        public IdleState(EnemyMovementStateMachine stateMachine) : base(stateMachine) {}

        public override void OnEnterState(){
            stateMachine.navmeshAgent.isStopped = true;
            this.idleDuration = stateMachine.IdleDuration;
        }

        public override void Tick(){
            idleDuration -= Time.deltaTime;
            if(stateMachine.enemy.PlayerDetected){
                stateMachine.ChangeState(new ChaseState(stateMachine));
            }
            else if(idleDuration <= 0){
                stateMachine.ChangeState(new RoamState(stateMachine));
            }
        }
    }
}
