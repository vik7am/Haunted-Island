using UnityEngine;

public class IdleState : BaseState
{
    private float idleDuration;

    public IdleState(EnemyMovementStateMachine stateMachine) : base(stateMachine) {}

    public override void OnEnterState(){
        this.idleDuration = stateMachine.idleDuration;
    }

    public override void Tick(){
        idleDuration -= Time.deltaTime;
        if(idleDuration<=0){
            stateMachine.ChangeState(new RoamState(stateMachine));
        }
    }
}
