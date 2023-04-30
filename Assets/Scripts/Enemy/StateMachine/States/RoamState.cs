using UnityEngine;
using UnityEngine.AI;

public class RoamState : BaseState
{
    private NavMeshAgent navmeshAgent;
    private Vector3 destination;
    private bool destinationFound;
    private float roamRange = 20;

    public RoamState(EnemyMovementStateMachine stateMachine) : base(stateMachine) {
        navmeshAgent = stateMachine.navmeshAgent;
    }

    public override void Tick(){
        if(destinationFound)
            CheckDistance();
        else
            FindNextDestination();
    }

    public void CheckDistance(){
        float distance = Vector3.Distance(stateMachine.transform.position, destination);
        if(distance <= navmeshAgent.stoppingDistance){
            destinationFound = false;
        }
    }

    public void FindNextDestination(){
        destinationFound = false;
        Vector3 result;
        if(TryToFindRandomPoint(stateMachine.transform.position, roamRange, out result)){
            destination = result;
            navmeshAgent.SetDestination(destination);
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