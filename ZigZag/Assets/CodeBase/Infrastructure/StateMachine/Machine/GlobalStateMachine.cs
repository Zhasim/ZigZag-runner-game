using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StateMachine.GameStates;
using CodeBase.Infrastructure.StateMachine.States;

namespace CodeBase.Infrastructure.StateMachine.Machine
{
    public class GlobalStateMachine : IGlobalStateMachine
    {
    private readonly Dictionary<Type, IExitState> _states;
    private IExitState _currentState;

    public GlobalStateMachine(BootstrapState.Factory bootstrapStateFactory,
        LoadProgressState.Factory loadProgressStateFactory,
        LoadSceneState.Factory loadSceneStateFactory,
        GameLoopState.Factory gameLoopStateFactory)
    {
        _states = new Dictionary<Type, IExitState>();
        
        RegisterState(bootstrapStateFactory.Create(this));
        RegisterState(loadProgressStateFactory.Create(this));
        RegisterState(loadSceneStateFactory.Create(this));
        RegisterState(gameLoopStateFactory.Create(this));
    }

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

    protected void RegisterState<TState>(TState state) where TState : IExitState =>
        _states.Add(typeof(TState), state);

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
