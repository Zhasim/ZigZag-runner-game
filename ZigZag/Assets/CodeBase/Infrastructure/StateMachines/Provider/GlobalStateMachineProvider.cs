using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.StateMachines.GameLoopMachine;
using CodeBase.Infrastructure.StateMachines.GameStates;
using CodeBase.Infrastructure.StateMachines.Machines;
using Zenject;

namespace CodeBase.Infrastructure.StateMachines.Provider
{
    public class GlobalStateMachineProvider : IGlobalStateMachineProvider
    {
        private readonly DiContainer _container;
        private readonly GlobalStateMachine _stateMachine;
        
        public GlobalStateMachineProvider(DiContainer container)
        {
            _container = container;
            _stateMachine = new GlobalStateMachine();
            
            BootstrapState bootsTrapState = new BootstrapState(_stateMachine,
                _container.Resolve<IAdsService>(), 
                _container.Resolve<IStaticDataService>());
            _stateMachine.RegisterState(bootsTrapState);
            
            LoadProgressState loadProgressState = new LoadProgressState(_stateMachine,
                _container.Resolve<IProgressService>(),
                _container.Resolve<ISaveLoadService>());
            _stateMachine.RegisterState(loadProgressState);
            
            LoadSceneState loadSceneState = new LoadSceneState(_stateMachine,
                _container.Resolve<ISceneLoader>(),
                _container.Resolve<ILoadingCurtain>(),
                _container.Resolve<IGameFactory>());
            _stateMachine.RegisterState(loadSceneState);
            
            GameLoopState gameLoopState = new GameLoopState(_stateMachine,
                _container.Resolve<IGameLoopStateMachine>());
            _stateMachine.RegisterState(gameLoopState);
        }

        public GlobalStateMachine GetStateMachine() =>
            _stateMachine;
        
    }
}