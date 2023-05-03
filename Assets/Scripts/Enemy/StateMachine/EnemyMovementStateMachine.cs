using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland
{
    public class EnemyMovementStateMachine : MonoBehaviour, IDetector
    {
        [field: SerializeField] public float idleDuration {get; private set;}
        [field: SerializeField] public float roamRange {get; private set;}
        [field: SerializeField] public float chaseRange {get; private set;}
        public NavMeshAgent navmeshAgent {get; private set;}
        public bool playerDetected {get; private set;}
        public Transform playerTransform {get; private set;}
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

        public void Detect(Transform other)
        {
            playerDetected = true;
            playerTransform = other;
        }

        public void PlayerOutOfRange(){
            playerDetected = false;
            playerTransform = null;
        }
    }
}