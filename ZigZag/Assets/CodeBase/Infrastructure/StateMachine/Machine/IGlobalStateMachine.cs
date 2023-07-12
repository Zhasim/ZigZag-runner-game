using CodeBase.Infrastructure.StateMachine.States;

namespace CodeBase.Infrastructure.StateMachine.Machine
{
    public interface IGlobalStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}