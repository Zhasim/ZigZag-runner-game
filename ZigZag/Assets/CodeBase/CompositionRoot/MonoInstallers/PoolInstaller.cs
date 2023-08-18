using CodeBase.Entity.Blocks;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.Infrastructure.Services.Pool.Factory;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Logic.TileGeneration.Creator;
using Zenject;

namespace CodeBase.CompositionRoot.MonoInstallers
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLocalFactories();
            BindGenericPools();
            BindPools();
            BindTileGenerator();
        }

        private void BindLocalFactories()
        {
            Container.Bind(typeof(ILocalFactory<Block>)).To(typeof(LocalFactory<Block>)).AsSingle();
            Container.Bind(typeof(ILocalFactory<Diamond>)).To(typeof(LocalFactory<Diamond>)).AsSingle();
        }

        private void BindGenericPools()
        {
            Container.Bind(typeof(IGenericPool<Block>)).To(typeof(GenericPool<Block>)).AsSingle();
            Container.Bind(typeof(IGenericPool<Diamond>)).To(typeof(GenericPool<Diamond>)).AsSingle();
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