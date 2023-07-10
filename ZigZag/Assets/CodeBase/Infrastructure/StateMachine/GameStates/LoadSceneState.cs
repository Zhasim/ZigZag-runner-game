using CodeBase.Infrastructure.Foundation;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.Infrastructure.StateMachine.Machine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.Logic.Camera;
using CodeBase.Logic.TileGeneration;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.StateMachine.GameStates
{
    public class LoadSceneState :  IPayloadState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGlobalStateMachine _stateMachine;
        private readonly IGameFactory _factory;
        private readonly IPoolService _poolService;
        private readonly IRandomService _randomService;
        

        public LoadSceneState(IGlobalStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory factory, IPoolService poolService, IRandomService randomService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _factory = factory;
            _poolService = poolService;
            _randomService = randomService;
        }

        public void Enter(string sceneName)
        {
            Debug.Log($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            GameObject hero = _factory.CreatePlayer();
            CameraFollow(hero);
            
            _factory.CreateInitPlatform();
            _factory.CreateBlock();
            _factory.CreateDiamond();
            
            InitPools();
            InitTileGenerator();


            Debug.Log("Game World INIT");
        }

        private void InitPools()
        {
            _factory.CreateBlocksPool();
            _factory.CreateDiamondsPool();
        }

        private void InitTileGenerator()
        {
            GameObject tileGenerator = _factory.CreateTileGenerator();
            tileGenerator.GetComponent<TileGenerator>().Construct(_poolService, _randomService);
        }

        public void Exit() => 
            Debug.Log($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        
        private static void CameraFollow(GameObject hero)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}