using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.States;
using CodeBase.Logic.Camera;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.StateMachines.GameStates
{
    public class LoadSceneState : IPayloadState<string>
    {
        private readonly IGlobalStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IGameFactory _factory;
        
        public LoadSceneState(IGlobalStateMachine stateMachine, 
            ISceneLoader sceneLoader,
            ILoadingCurtain loadingCurtain,
            IGameFactory factory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _factory = factory;
        }

        public void Enter(string sceneName)
        {
            Debug.Log($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
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
             // GameObject hero = _factory.CreatePlayer();
             // CameraFollow(hero);

            //InitInitialPlatform();
            Debug.Log("Game World INIT");
        }

        // private void InitInitialPlatform()
        // {
        //     _factory.CreateInitPlatform();
        //     _factory.CreateBlock();
        //     _factory.CreateDiamond();
        // }

        public void Exit()
        {
            _loadingCurtain.Hide();
            Debug.Log($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
        }

        private static void CameraFollow(GameObject hero)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}