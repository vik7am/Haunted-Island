using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland.Ghost
{
    public class GhostStateMachine : MonoBehaviour
    {
        [SerializeField] private float idleDuration;
        [SerializeField] private float roamRange;
        private IdleState idleState;
        private PatrolState patrolState;
        private RoamState roamState;
        private NavMeshAgent navmeshAgent;
        private GhostState currentGhostState;
        private GhostController ghostController;

        public float IdleDuration => idleDuration;
        public float RoamRange => roamRange;
        public IdleState IdleState => idleState;
        public PatrolState PatrolState => patrolState;
        public RoamState RoamState => roamState;
        public NavMeshAgent NavMeshAgent => navmeshAgent;
        public GhostController GhostController => ghostController;
        
        private void Awake() {
            navmeshAgent = GetComponent<NavMeshAgent>();
            ghostController = GetComponent<GhostController>();
            InitializeStates();
        }

        private void InitializeStates(){
            idleState = new IdleState(this);
            patrolState = new PatrolState(this);
            roamState = new RoamState(this);
        }

        private void Start() {
            ChangeState(idleState);
        }

        private void Update() {
            currentGhostState.Update();
        }

        public void ChangeState(GhostState ghostState){
            if(currentGhostState != null)
                currentGhostState.OnExitState();
            currentGhostState = ghostState;
            if(currentGhostState != null)
                currentGhostState.OnEnterState();
        }
    }
}
