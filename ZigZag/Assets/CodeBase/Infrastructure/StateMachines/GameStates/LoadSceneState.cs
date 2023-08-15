using CodeBase.Entity.Player;
using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using CodeBase.Logic.Camera;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class LoadSceneState : IPayloadState<string>
    {
        private readonly IGlobalStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IGameFactory _factory;
        private readonly ILogger _logger;

        public LoadSceneState(IGlobalStateMachine stateMachine, 
            ISceneLoader sceneLoader,
            ILoadingCurtain loadingCurtain,
            IGameFactory factory, 
            ILogger logger)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _factory = factory;
            _logger = logger;
        }

        public void Enter(string sceneName)
        {
            _logger.LogInfo($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
             GameObject player = _factory.CreatePlayer();
             PlayerDeath playerDeath = player.GetComponent<PlayerDeath>();
             
             CameraInit(playerDeath, player);
                 
            _logger.LogInfo("Game World INIT");
        }
        
        public void Exit()
        {
            _loadingCurtain.Hide();
            _logger.LogInfo($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        }

        private void CameraInit(PlayerDeath player, GameObject target)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().InitFollow(player, target);
        }
        
        public class Factory : PlaceholderFactory<IGlobalStateMachine, LoadSceneState>
        {
        }
    }
}