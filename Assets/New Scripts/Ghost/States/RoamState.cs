using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland.Ghost
{
    public class RoamState : GhostState
    {
        private Vector3 destination;
        private bool destinationFound;

        public RoamState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine)
        {
        }

        public override void OnEnterState(){
            ghostStateMachine.NavMeshAgent.isStopped = false;
            destinationFound = false;
        }

        public override void Update()
        {
            if(destinationFound)
                CheckDistance();
            else
                FindNextDestination();
        }

        public void CheckDistance(){
            float distance = Vector3.Distance(ghostStateMachine.transform.position, destination);
            if(distance <= ghostStateMachine.NavMeshAgent.stoppingDistance){
                ghostStateMachine.ChangeState(ghostStateMachine.PatrolState);
            }
        }

        public void FindNextDestination(){
            destinationFound = false;
            Vector3 result;
            if(TryToFindRandomPoint(ghostStateMachine.transform.position, ghostStateMachine.RoamRange, out result)){
                destination = result;
                ghostStateMachine.NavMeshAgent.SetDestination(destination);
                destinationFound = true;
            }
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
