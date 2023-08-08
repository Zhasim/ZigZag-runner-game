namespace CodeBase.Infrastructure.StateMachines.GameLoopMachine
{
    public class GameLoopStateMachine : IGameLoopStateMachine
    {
        private IGameLoopSubState _currentState;

        public void SetState(IGameLoopSubState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        public void Update() => 
            _currentState?.Update();
    }
}