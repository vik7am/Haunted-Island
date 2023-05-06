using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland
{
    public class EnemyMovementStateMachine : MonoBehaviour
    {
        [field: SerializeField] public float idleDuration {get; private set;}
        [field: SerializeField] public float roamRange {get; private set;}
        [field: SerializeField] public float chaseRange {get; private set;}
        [field: SerializeField] public float attackRange {get; private set;}
        public NavMeshAgent navmeshAgent {get; private set;}
        private BaseState currentState;
        public Enemy enemy {get; private set;}

        private void Awake() {
            navmeshAgent = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Enemy>();
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
}