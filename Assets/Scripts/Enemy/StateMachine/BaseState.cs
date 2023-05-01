namespace HauntedIsland
{
    public abstract class BaseState 
    {
        protected EnemyMovementStateMachine stateMachine;

        public BaseState(EnemyMovementStateMachine stateMachine){
            this.stateMachine = stateMachine;
        }

        public abstract void Tick();
        public virtual void OnEnterState() {}
        public virtual void OnExitState() {}
    }
}