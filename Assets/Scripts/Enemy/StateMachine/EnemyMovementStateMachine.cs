using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementStateMachine : MonoBehaviour
{
    public float idleDuration;
    public NavMeshAgent navmeshAgent;
    private BaseState currentState;

    private void Awake() {
        navmeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start() {
        ChangeState(new IdleState(this));
    }

    private void Update() {
        currentState.Tick();
    }

    public void ChangeState(BaseState state){
        if(currentState != null)
            currentState.OnExitState();
        currentState = state;
        if(currentState != null)
            currentState.OnEnterState();
    }
}
