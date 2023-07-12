using CodeBase.Infrastructure.Foundation;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.Infrastructure.Services.RegistrationService;
using CodeBase.Infrastructure.StateMachine.Machine;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace CodeBase.DI
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindStateMachine();

            BindInputService();
            BindRegistrationService();
            BindPoolService();
            BindRandomService();
            BindGameFactory();

            BindUIFactory();
            BindWindowService();
        }
        

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindWindowService()
        {
            Container
                .Bind<IWindowService>()
                .To<WindowService>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void BindRandomService()
        {
            Container
                .Bind<IRandomService>()
                .To<RandomService>()
                .AsSingle();
        }

        private void BindPoolService()
        {
            Container
                .Bind<IPoolService>()
                .To<PoolService>()
                .AsSingle();
        }

        private void BindRegistrationService()
        {
            Container
                .Bind<IRegistrationService>()
                .To<RegistrationService>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IGlobalStateMachine>()
                .To<GlobalStateMachine>()
                .AsSingle();
        }

        private void BindInputService()
        {
            if (Application.isEditor)
                BindStandaloneInputService();
            else
                BindMobileInputService();
        }

        private void BindMobileInputService()
        {
            Container
                .Bind<IInputService>()
                .To<MobileInputService>()
                .AsSingle();
        }

        private void BindStandaloneInputService()
        {
            Container
                .Bind<IInputService>()
                .To<StandaloneInputService>()
                .AsSingle();
        }
    }
}