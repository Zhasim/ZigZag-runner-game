using CodeBase.Infrastructure.Foundation;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.Logic.Camera;
using CodeBase.StaticData;
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
        

        public LoadSceneState(IGlobalStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory factory, IPoolService poolService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _factory = factory;
            _poolService = poolService;
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
            _factory.CreateBlockPool();
            Debug.Log("Game World INIT");
        }

        public void Exit() => 
            Debug.Log($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        
        private static void CameraFollow(GameObject hero)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}