using CodeBase.Infrastructure.StateMachines.States;

namespace CodeBase.Infrastructure.StateMachines.Machines
{
    public interface IGlobalStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}