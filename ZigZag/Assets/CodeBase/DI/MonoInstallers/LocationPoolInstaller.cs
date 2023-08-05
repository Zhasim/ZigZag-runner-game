using CodeBase.Entity;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pools.BlockPool;
using CodeBase.Infrastructure.Services.Pools.DiamondPool;
using CodeBase.Logic;
using CodeBase.Logic.TileGeneration;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.MonoInstallers
{
    public class LocationPoolInstaller : MonoInstaller
    {
        private const int DIAMONDS_INIT_COUNT = 15;
        private const int DIAMONDS_MAX_COUNT = 30;
        private const string DIAMONDS_CONTAINER = "Diamonds";
        
        private const int BLOCKS_INIT_COUNT = 30;
        private const int BLOCKS_MAX_COUNT = 50;
        private const string BLOCKS_CONTAINER = "Blocks";
        
        public GameObject blockPrefab;
        public GameObject diamondPrefab;
        public override void InstallBindings()
        {
            BindBlockPool();
            BindDiamondPool();
            
            BindTileGenerator();
            BindGame();
        }

        private void BindDiamondPool()
        {
            Container
                .Bind<IDiamondPool>()
                .To<DiamondPool>()
                .AsSingle();
            
            Container
                .BindMemoryPool<Diamond, Diamond.Pool>()
                .WithInitialSize(DIAMONDS_INIT_COUNT)
                .WithMaxSize(DIAMONDS_MAX_COUNT)
                .ExpandByDoubling()
                .FromComponentInNewPrefab(diamondPrefab)
                .UnderTransformGroup(DIAMONDS_CONTAINER);
        }

        private void BindBlockPool()
        {
            Container
                .Bind<IBlockPool>()
                .To<BlockPool>()
                .AsSingle();
            
            Container
                .BindMemoryPool<Block, Block.Pool>()
                .WithInitialSize(BLOCKS_INIT_COUNT)
                .WithMaxSize(BLOCKS_MAX_COUNT)
                .ExpandByDoubling()
                .FromComponentInNewPrefab(blockPrefab)
                .UnderTransformGroup(BLOCKS_CONTAINER);
        }

        private void BindGame()
        {
            Container
                .BindInterfacesAndSelfTo<Game>()
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