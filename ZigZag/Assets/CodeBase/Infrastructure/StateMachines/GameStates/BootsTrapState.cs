using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class BootstrapState : IState
    {
        private readonly IGlobalStateMachine _stateMachine;
        private readonly IAdsService _adsService;
        private readonly IStaticDataService _staticDataService;
        private readonly ILogger _logger;

        public BootstrapState(IGlobalStateMachine stateMachine,
            IAdsService adsService,
            IStaticDataService staticDataService, 
            ILogger logger)
        {
            _stateMachine = stateMachine;
            _adsService = adsService;
            _staticDataService = staticDataService;
            _logger = logger;
        }

        public void Enter()
        {
            _logger.LogInfo($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            
            InitServices();
            _stateMachine.Enter<LoadProgressState>();
        }

        private void InitServices()
        {
            _adsService.Initialize();
            _staticDataService.Initialize();
        }
        
        public void Exit() => 
            _logger.LogInfo($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        public class Factory : PlaceholderFactory<IGlobalStateMachine, BootstrapState>
        {
        }
    }
}