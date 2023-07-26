using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland.Ghost
{
    public class RoamState : GhostState
    {
        private Vector3 destination;
        private bool destinationFound;
        private NavMeshAgent navMeshAgent;
        private float currentIdleDuration;

        public RoamState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine){
            navMeshAgent = ghostStateMachine.NavMeshAgent;
        }

        public override void OnEnterState(){
            navMeshAgent.isStopped = false;
            destinationFound = false;
        }

        public override void Update(){
            if(destinationFound){
                CheckDistance();
                CheckIdleState();
            }
            else
                FindNextDestination();
            
        }

        public void CheckDistance(){
            float distance = Vector3.Distance(ghostStateMachine.transform.position, destination);
            if(distance <= navMeshAgent.stoppingDistance){
                ghostStateMachine.ChangeState(ghostStateMachine.PatrolState);
            }
        }

        public void FindNextDestination(){
            destinationFound = false;
            Vector3 result;
            if(TryToFindRandomPoint(ghostStateMachine.transform.position, ghostStateMachine.RoamRange, out result)){
                destination = result;
                navMeshAgent.SetDestination(destination);
                destinationFound = true;
            }
        }

        private void CheckIdleState(){
            if(navMeshAgent.velocity.magnitude < Mathf.Epsilon){
                currentIdleDuration += Time.deltaTime;
                if(currentIdleDuration >= ghostStateMachine.IdleDuration){
                    FindNextDestination();
                    currentIdleDuration = 0;
                }
            }
            else
                currentIdleDuration = 0;
        }

        public bool TryToFindRandomPoint(Vector3 origin, float range, out Vector3 result){
            Vector3 randomPoint = origin + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)){
                result = hit.position;
                return true;
            }
            result = Vector3.zero;
            return false;
        }
    }
}
