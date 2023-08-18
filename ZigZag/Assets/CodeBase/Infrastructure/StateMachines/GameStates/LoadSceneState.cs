using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using CodeBase.Logic.Camera;
using CodeBase.Logic.TileGeneration.Creator;
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
        private readonly ILogger _logger;

        private readonly IGameFactory _factory;
        private readonly ITileGenerator _tileGenerator;

        public LoadSceneState(IGlobalStateMachine stateMachine, 
            ISceneLoader sceneLoader,
            ILoadingCurtain loadingCurtain,
            ILogger logger,
            IGameFactory factory,
            ITileGenerator tileGenerator)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _logger = logger;
            _factory = factory;
            _tileGenerator = tileGenerator;
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
            Transform initContainer = new GameObject("INIT_CONTAINER").transform;
           _factory.CreateInitPlatform(initContainer);
            Vector3 initPoint = _factory.CreateInitPoint(initContainer).transform.position;

            Transform playerContainer = new GameObject("PLAYER_CONTAINER").transform;
            GameObject player = _factory.CreatePlayer(initPoint, playerContainer);
            
            _tileGenerator.Init(player.transform);
            CameraFollow(player);
            _logger.LogInfo("Game World INIT");
        }
        
        public void Exit()
        {
            _loadingCurtain.Hide();
            _logger.LogInfo($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        }

        private void CameraFollow(GameObject target)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(target);
        }
        
        public class Factory : PlaceholderFactory<IGlobalStateMachine, LoadSceneState>
        {
        }
    }
}