using CodeBase.Entity;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.Infrastructure.Services.Pool.Factory;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Logic.TileGeneration;
using Zenject;

namespace CodeBase.CompositionRoot.MonoInstallers
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLocalFactories();
            BindPoolBuilders();
            BindPools();
            BindTileGenerator();
        }

        private void BindLocalFactories()
        {
            Container.Bind(typeof(ILocalFactory<Block>)).To(typeof(LocalFactory<Block>)).AsSingle();
            Container.Bind(typeof(ILocalFactory<Diamond>)).To(typeof(LocalFactory<Diamond>)).AsSingle();
        }

        private void BindPoolBuilders()
        {
            Container.Bind(typeof(IPoolBuilder<Block>)).To(typeof(PoolBuilder<Block>)).AsSingle();
            Container.Bind(typeof(IPoolBuilder<Diamond>)).To(typeof(PoolBuilder<Diamond>)).AsSingle();
        }

        private void BindPools()
        {
            Container
                .Bind<IBlocksPool>()
                .To<BlocksPool>()
                .AsSingle();
            
            Container
                .Bind<IDiamondsPool>()
                .To<DiamondsPool>()
                .AsSingle();
        }
        private void BindTileGenerator()
        {
            Container
                .BindInterfacesAndSelfTo<TileGenerator>()
                .AsSingle();
        }
    }
}