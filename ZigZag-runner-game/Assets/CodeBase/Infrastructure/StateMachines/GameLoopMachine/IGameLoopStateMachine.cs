namespace CodeBase.Infrastructure.StateMachines.GameLoopMachine
{
    public interface IGameLoopStateMachine
    {
        void SetState(IGameLoopSubState newState);
        void Update();
    }
}