
namespace HauntedIsland.Ghost
{
    public abstract class GhostState
    {
        protected GhostStateMachine ghostStateMachine;

        public GhostState(GhostStateMachine ghostStateMachine){
            this.ghostStateMachine = ghostStateMachine;
        }

        public abstract void Update();
        public virtual void OnEnterState() {}
        public virtual void OnExitState() {}
    }
}
