using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland.Old
{
    public class EnemyMovementStateMachine : MonoBehaviour
    {
        [SerializeField] private float idleDuration;
        [SerializeField] private float roamRange;
        [SerializeField] private float chaseRange;
        [SerializeField] private float attackRange;
        [SerializeField] private Enemy enemy;
        private BaseState currentState;
        public NavMeshAgent navmeshAgent {get; private set;}
        public Enemy Enemy => enemy;

        public float IdleDuration {get => idleDuration;}
        public float RoamRange {get => roamRange;}
        public float ChaseRange {get => chaseRange;}
        public float AttackRange {get => attackRange;}

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