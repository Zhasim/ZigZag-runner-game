using CodeBase.Infrastructure.StateMachines.GameLoopMachine;
using CodeBase.Infrastructure.StateMachines.GameStates;
using CodeBase.Infrastructure.StateMachines.Machines;
using Zenject;

namespace CodeBase.DI.SubContainers
{
    public class GlobalStateMachineInstaller : Installer<GlobalStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            BindGameLoopStateMachine();

            BindGlobalStates();
            BindGlobalStateMachine();
        }

        private void BindGameLoopStateMachine()
        {
            Container
                .Bind<IGameLoopStateMachine>()
                .To<GameLoopStateMachine>()
                .AsSingle();
        }

        private void BindGlobalStates()
        {
            Container.BindFactory<IGlobalStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGlobalStateMachine, LoadProgressState, LoadProgressState.Factory>();
            Container.BindFactory<IGlobalStateMachine, LoadSceneState, LoadSceneState.Factory>();
            Container.BindFactory<IGlobalStateMachine, GameLoopState, GameLoopState.Factory>();
        }

        private void BindGlobalStateMachine()
        {
            Container
                .Bind<IGlobalStateMachine>()
                .To<GlobalStateMachine>()
                .AsSingle();
        }
    }
}