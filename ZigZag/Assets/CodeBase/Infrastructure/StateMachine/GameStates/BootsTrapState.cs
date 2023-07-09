using CodeBase.DI;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Foundation;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.RegistrationService;
using CodeBase.Infrastructure.StateMachine.Machine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.StateMachine.GameStates
{
    public class BootsTrapState : IState
    {
        private readonly GlobalStateMachine _stateMachine;
        private readonly ServiceLocator _services;
        private readonly SceneLoader _sceneLoader;


        public BootsTrapState(GlobalStateMachine stateMachine, ServiceLocator services, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _services = services;
            _sceneLoader = sceneLoader;

            RegisterServices();
        }

        public void Enter()
        {
            Debug.Log($"Entered to State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");
            
            _sceneLoader.Load(ScenesID.INIT, OnLoaded);
        }

        private void OnLoaded() => 
            _stateMachine.Enter<LoadSceneState, string>(ScenesID.GAME_LOOP);

        public void Exit() => 
            Debug.Log($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");

        private void RegisterServices()
        {
            _services.RegisterSingle<IGlobalStateMachine>(_stateMachine);
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IRegistrationService>(new RegistrationService());
            _services.RegisterSingle<IPoolService>(new PoolService());
            
            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssetProvider>(),
                _services.Single<IRegistrationService>(),
                _services.Single<IPoolService>()));
        }
    }
}