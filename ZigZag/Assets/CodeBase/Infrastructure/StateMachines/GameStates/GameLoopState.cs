using CodeBase.Infrastructure.StateMachines.GameLoopMachine;
using CodeBase.Infrastructure.StateMachines.GameLoopMachine.SubStates;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class GameLoopState : IState, IInitializable, ITickable
    {
        private readonly IGlobalStateMachine _globalStateMachine;
        private readonly IGameLoopStateMachine _localStatMachine;

        private readonly IGameLoopSubState _startGameState;
        private readonly IGameLoopSubState _inGameState;
        private readonly IGameLoopSubState _endGameState;
        

        public GameLoopState(IGlobalStateMachine globalStateMachine, IGameLoopStateMachine localStatMachine)
        {
            _globalStateMachine = globalStateMachine;
            _localStatMachine = localStatMachine;

            _startGameState = new StartGameState();
            _inGameState = new InGameState();
            _endGameState = new EndGameState();
        }

        public void Enter()
        {
            Debug.Log($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            _localStatMachine.SetState(_startGameState);
        }

        public void Exit()
        {
        }

        public void Initialize()
        {
        }

        public void Tick()
        {
        }
        public class Factory : PlaceholderFactory<IGlobalStateMachine, GameLoopState>
        {
        }
    }
}