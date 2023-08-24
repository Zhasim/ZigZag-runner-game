using System;

namespace CodeBase.Infrastructure.StateMachines.GameLoopMachine
{
    public interface IGameLoopSubState
    {
        event Action EnterState;
        event Action ExitState;

        void Enter();
        void Exit();
        void Update();
    }
}