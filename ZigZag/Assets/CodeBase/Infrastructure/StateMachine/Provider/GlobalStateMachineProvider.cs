using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.StateMachine.GameStates;
using CodeBase.Infrastructure.StateMachine.Machine;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.Provider
{
    public class GlobalStateMachineProvider : IGlobalStateMachineProvider
    {
        private readonly DiContainer _diContainer;
        private readonly GlobalStateMachine _stateMachine;
        
        public GlobalStateMachineProvider(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _stateMachine = new GlobalStateMachine();
            
            BootstrapState bootsTrapState = new BootstrapState(_stateMachine,
                _diContainer.Resolve<IAdsService>(), 
                _diContainer.Resolve<IStaticDataService>());
            _stateMachine.RegisterState(bootsTrapState);
        
            LoadProgressState loadProgressState = new LoadProgressState(_stateMachine,
                _diContainer.Resolve<IProgressService>(),
                _diContainer.Resolve<ISaveLoadService>());
            _stateMachine.RegisterState(loadProgressState);
        
            LoadSceneState loadSceneState = new LoadSceneState(_stateMachine,
                _diContainer.Resolve<ISceneLoader>(),
                _diContainer.Resolve<ILoadingCurtain>(),
                _diContainer.Resolve<IGameFactory>());
            _stateMachine.RegisterState(loadSceneState);
        
            GameLoopState gameLoopState = new GameLoopState(_stateMachine);
            _stateMachine.RegisterState(gameLoopState);
        }

        public GlobalStateMachine GetStateMachine() =>
            _stateMachine;
        
    }
}