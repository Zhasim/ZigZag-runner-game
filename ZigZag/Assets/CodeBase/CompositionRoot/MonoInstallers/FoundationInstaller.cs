using CodeBase.CompositionRoot.SubContainers;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.StaticData;
using Zenject;

namespace CodeBase.CompositionRoot.MonoInstallers
{
    public class FoundationInstaller : MonoInstaller
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
                .FromComponentInNewPrefabResource(ResourcePath.COROUTINE_RUNNER)
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
                .FromComponentInNewPrefabResource(ResourcePath.CURTAIN)
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