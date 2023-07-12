using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.UI.Services.Factory;
using Zenject;

namespace CodeBase.DI.MonoInstallers.ProjectContext
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAssetProvider();
            
            BindPoolService();
            
            BindGameFactory();
            
            BindUIFactory();
        }
        
        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }
        
        private void BindPoolService()
        {
            Container
                .Bind<IPoolService>()
                .To<PoolService>()
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