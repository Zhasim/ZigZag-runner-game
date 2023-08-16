using CodeBase.Infrastructure.ResourceLoad;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Pools.BlockPool;
using CodeBase.Infrastructure.Services.Pools.DiamondPool;
using CodeBase.UI.Services.Factory;
using Zenject;

namespace CodeBase.CompositionRoot.MonoInstallers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindResourceLoader();

            BindGameFactory();

            BindPools();
            
            BindUIFactory();
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

        private void BindPools()
        {
            BindBlocksPool();
            BindDiamondsPool();
        }

        private void BindBlocksPool()
        {
            Container
                .Bind<IBlockPool>()
                .To<BlockPool>()
                .AsSingle();
        }

        private void BindDiamondsPool()
        {
            Container
                .Bind<IDiamondPool>()
                .To<DiamondPool>()
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