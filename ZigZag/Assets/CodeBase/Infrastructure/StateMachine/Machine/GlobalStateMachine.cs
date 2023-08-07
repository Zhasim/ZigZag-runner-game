using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine.States;

namespace CodeBase.Infrastructure.StateMachine.Machine
{
    public class GlobalStateMachine : IGlobalStateMachine
    {
        private readonly Dictionary<Type, IExitState> _states;
        private IExitState _currentState;

        public GlobalStateMachine() =>
            _states = new Dictionary<Type, IExitState>();

        public void RegisterState<TState>(TState state) where TState : IExitState =>
            _states.Add(typeof(TState), state);

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state?.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state?.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitState =>
            _states[typeof(TState)] as TState;
    }
}
