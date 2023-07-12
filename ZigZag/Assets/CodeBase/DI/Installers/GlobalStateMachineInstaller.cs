using CodeBase.Infrastructure.StateMachine.GameStates;
using CodeBase.Infrastructure.StateMachine.Machine;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.Installers
{
    public class GlobalStateMachineInstaller : Installer<GlobalStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGlobalStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGlobalStateMachine, LoadProgressState, LoadProgressState.Factory>();
            Container.BindFactory<IGlobalStateMachine, LoadSceneState, LoadSceneState.Factory>();
            Container.BindFactory<IGlobalStateMachine, GameLoopState, GameLoopState.Factory>();
         
            Container.Bind<IGlobalStateMachine>().To<GlobalStateMachine>().AsSingle();
            
            Debug.Log("GameStateMachineInstaller");
        }
    }
}