using CodeBase.Infrastructure.ResourceLoad;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Windows;
using Zenject;

namespace CodeBase.CompositionRoot.MonoInstallers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindResourceLoader();

            BindUIFactory();

            BindWindowService();
            
            BindGameFactory();
        }

        private void BindWindowService()
        {
            Container
                .Bind<IWindowService>()
                .To<WindowService>()
                .AsSingle();
        }

        private void BindResourceLoader()
        {
            Container
                .Bind<IResourceLoader>()
                .To<ResourceLoader>()
                .AsSingle();
        }

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }
        
        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();
        }
    }
}