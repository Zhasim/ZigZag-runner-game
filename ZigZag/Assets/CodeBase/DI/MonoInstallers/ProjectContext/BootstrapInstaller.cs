using CodeBase.DI.Installers;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Foundation;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.StateMachine.Machine;
using Zenject;

namespace CodeBase.DI.MonoInstallers.ProjectContext
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBootstrapper();

            BindCoroutineRunner();
            
            BindSceneLoader();
            
            BindLoadingCurtain();
            
            BindGlobalStateMachine();
        }
        
        private void BindBootstrapper()
        {
            Container
                .BindFactory<Bootstrapper, Bootstrapper.Factory>()
                .FromComponentInNewPrefabResource(AssetPath.Bootstrapper);
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(AssetPath.CoroutineRunnerPath)
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
                .FromComponentInNewPrefabResource(AssetPath.CurtainPath)
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