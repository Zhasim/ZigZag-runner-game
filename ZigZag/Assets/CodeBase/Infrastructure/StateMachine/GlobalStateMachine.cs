using System;
using System.Collections.Generic;
using CodeBase.DI;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Foundation;
using CodeBase.Infrastructure.StateMachine.GameStates;
using CodeBase.Infrastructure.StateMachine.States;

namespace CodeBase.Infrastructure.StateMachine
{
    public class GlobalStateMachine : IGlobalStateMachine
    {
    private readonly Dictionary<Type, IExitState> _states;
    private IExitState _currentState;

    public GlobalStateMachine(SceneLoader sceneLoader, ServiceLocator services)
    {
        _states = new Dictionary<Type, IExitState>
        {
            [typeof(BootsTrapState)] = new BootsTrapState(this, services, sceneLoader),
            [typeof(LoadProgressState)] = new LoadProgressState(),
            [typeof(LoadSceneState)] = new LoadSceneState(this, sceneLoader, services.Single<IGameFactory>()),
            [typeof(GameLoopState)] = new GameLoopState(),
        };
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
