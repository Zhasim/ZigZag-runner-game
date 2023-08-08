using CodeBase.Infrastructure.StateMachines.GameLoopMachine;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.Provider;
using Zenject;

namespace CodeBase.DI.MonoInstallers
{
    public class GlobalStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameLoopStateMachine();
            BindGlobalStateMachineProvider();
            BindGlobalStateMachine();
        }
        

        private void BindGlobalStateMachineProvider()
        {
            Container
                .Bind<IGlobalStateMachineProvider>()
                .To<GlobalStateMachineProvider>()
                .AsSingle();
        }
        

        private void BindGlobalStateMachine()
        {
            Container
                .Bind<IGlobalStateMachine>()
                .FromMethod(GetStateMachine)
                .AsSingle();
        }

        private void BindGameLoopStateMachine()
        {
            Container
                .Bind<IGameLoopStateMachine>()
                .To<GameLoopStateMachine>()
                .AsSingle();
        }
        
        private GlobalStateMachine GetStateMachine(InjectContext context)
        {
            var provider = context.Container.Resolve<GlobalStateMachineProvider>();
            return provider.GetStateMachine();
        }
    }
}