using System;

namespace CodeBase.Infrastructure.StateMachines.GameLoopMachine.SubStates
{
    public class StartGameState : IGameLoopSubState
    {
        public event Action EnterState;
        public event Action ExitState;
        public void Enter() => 
            EnterState?.Invoke();

        public void Exit() => 
            ExitState?.Invoke();

        public void Update()
        {
        }
    }
}