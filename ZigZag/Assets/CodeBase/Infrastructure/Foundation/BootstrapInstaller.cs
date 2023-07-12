using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.Randomizer;
using Zenject;

namespace CodeBase.Infrastructure.Foundation
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPoolService>()
                .To<PoolService>()
                .AsSingle();
            Container
                .Bind<IRandomService>()
                .To<RandomService>()
                .AsSingle();
        }
    }
}