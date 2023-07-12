using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.Pools;
using CodeBase.UI.Services.Factory;
using Zenject;

namespace CodeBase.DI.MonoInstallers.ProjectContext
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAssetProvider();
            
            BindPoolMono();
            
            BindPoolService();

            BindGameFactory();

            BindBlocksPool();
            
            BindUIFactory();
        }

        private void BindBlocksPool()
        {
            Container
                .Bind<IBlocksPool>()
                .To<BlocksPool>()
                .AsSingle();
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

        private void BindPoolMono()
        {
            Container
                .Bind(typeof(PoolMono<>))
                .To(typeof(PoolMono<>))
                .AsTransient();
        }
    }
}