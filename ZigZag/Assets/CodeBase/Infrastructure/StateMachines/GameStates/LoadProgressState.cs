using CodeBase.Data;
using CodeBase.Infrastructure.Services.CustomLogger;
using CodeBase.Infrastructure.Services.Progress.Generator;
using CodeBase.Infrastructure.Services.Progress.Service;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using CodeBase.StaticData;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly IGlobalStateMachine _stateMachine;
        private readonly IProgressService _progressService;
        private readonly IProgressGenerator _progressGenerator;
        private readonly ISaveLoadService _saveLoadService;
        private readonly ILogger _logger;

        public LoadProgressState(IGlobalStateMachine stateMachine, 
            IProgressService progressService,
            ISaveLoadService saveLoadService, 
            ILogger logger)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _logger = logger;
        }

        public void Enter()
        {
            _logger.LogInfo($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}"); 
            
            LoadProgressOrInitNew();
            _stateMachine.Enter<LoadSceneState, string>(ScenesID.GAME_LOOP);
        }

        private void LoadProgressOrInitNew()
        {
            OverallProgress loadedProgress = _saveLoadService.LoadProgress();
            _progressService.Progress = loadedProgress ?? _progressGenerator.GenerateNewProgress();
        }
        
        public void Exit() => 
            _logger.LogInfo($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        
        public class Factory : PlaceholderFactory<IGlobalStateMachine, LoadProgressState>
        {
        }
    }
}