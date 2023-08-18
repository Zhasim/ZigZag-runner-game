using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using CodeBase.Logic.TileGeneration.Creator;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class GameLoopState : IState, IInitializable, ITickable
    {
        private bool IsGameStarted;
        private bool IsGamePaused;
        private bool IsGameEnded;

        private readonly IGlobalStateMachine _globalStateMachine;
        private readonly ILogger _logger;
        private readonly IInputService _input;
        private readonly ITileGenerator _tileGenerator;
        public GameLoopState(IGlobalStateMachine globalStateMachine, 
            ILogger logger,
            IInputService input)
        {
            _globalStateMachine = globalStateMachine;
            _logger = logger;
            _input = input;
        }

        public void Initialize()
        {
            
        }

        public void Enter()
        {
            _logger.LogInfo($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            StarGame();
        }

        public void Tick()
        {
            
        }

        private void StarGame()
        {
            _logger.LogInfo("Game Started");
        }

        public void Exit()
        {
        }

        public class Factory : PlaceholderFactory<IGlobalStateMachine, GameLoopState>
        {
        }
    }
}