using CodeBase.DI.SubContainers;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.StateMachine.Machine;
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

            BindInput();
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

        private void BindInput()
        {
            Container
                .Bind<IInputService>()
                .FromSubContainerResolve()
                .ByInstaller<InputInstaller>()
                .AsSingle();
        }
    }
}