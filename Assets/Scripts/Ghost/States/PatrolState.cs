using UnityEngine;
using UnityEngine.AI;

namespace HauntedIsland.Ghost
{
    public class PatrolState : GhostState
    {
        private Bone bone;
        private Vector3 destination;
        private BoneManager boneManager;
        private NavMeshAgent navMeshAgent;

        public PatrolState(GhostStateMachine ghostStateMachine) : base(ghostStateMachine){
            boneManager = ghostStateMachine.GhostController.BoneManager;
            navMeshAgent = ghostStateMachine.NavMeshAgent;
        }

        public override void OnEnterState(){
            bone = boneManager.GetNextBone();
            bone.onBoneDestroyed += OnBoneDestroyed;
            destination = bone.transform.position;
            navMeshAgent.SetDestination(destination);
            navMeshAgent.isStopped = false;
        }

        private void OnBoneDestroyed(Bone bone){
            this.bone = boneManager.GetNextBone();
        }

        public override void Update(){
            destination = bone.transform.position;
            navMeshAgent.SetDestination(destination);
            CheckDestination();
        }

        private void CheckDestination(){
            float distance = Vector3.Distance(ghostStateMachine.transform.position, destination);
            if(distance < navMeshAgent.stoppingDistance){
                ghostStateMachine.ChangeState(ghostStateMachine.IdleState);
            }
        }
    }
}
