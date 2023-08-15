using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.StateMachines.Machines;
using Zenject;

namespace CodeBase.DI.MonoInstallers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCoroutineRunner();
            
            BindSceneLoader();
            
            BindLoadingCurtain();

            BindGlobalStateMachine();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(AssetPath.COROUTINE_RUNNER)
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindLoadingCurtain()
        {
            Container
                .Bind<ILoadingCurtain>()
                .To<LoadingCurtain>()
                .FromComponentInNewPrefabResource(AssetPath.CURTAIN)
                .AsSingle();
        }

        private void BindGlobalStateMachine()
        {
            Container
                .Bind<IGlobalStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GlobalStateMachineInstaller>()
                .AsSingle();
        }
    }
}