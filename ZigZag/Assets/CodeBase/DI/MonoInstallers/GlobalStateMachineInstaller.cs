using CodeBase.Infrastructure;
using CodeBase.Infrastructure.StateMachine.Machine;
using Zenject;

namespace CodeBase.DI.MonoInstallers
{
    public class GlobalStateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
        
        private GlobalStateMachine GetStateMachine(InjectContext context)
        {
            var provider = context.Container.Resolve<GlobalStateMachineProvider>();
            return provider.GetStateMachine();
        }
    }
}