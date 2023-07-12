using CodeBase.DI.Installers;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Foundation;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Foundation.Curtain;
using CodeBase.Infrastructure.Foundation.Loader;
using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.Infrastructure.Services.Registration;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.StateMachine.Machine;
using CodeBase.UI.Services.Factory;
using Zenject;

namespace CodeBase.DI.MonoInstallers
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
            
            BindStaticDataService();

            BindRandomService();
            
            BindProgressService();

            BindRegistrationService();

            BindAssetProvider();
            
            BindPoolService();

            BindGameFactory();
            
            BindUIFactory();

            BindSaveLoadService();

            BindAdsService();

            BindInputService();
        }

        private void BindAssetProvider()
        {
            Container
                .Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindRegistrationService()
        {
            Container
                .Bind<IRegistrationService>()
                .To<RegistrationService>()
                .AsSingle();
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

        private void BindStaticDataService()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
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

        private void BindRandomService()
        {
            Container
                .Bind<IRandomService>()
                .To<RandomService>()
                .AsSingle();
        }

        private void BindProgressService()
        {
            Container
                .Bind<IProgressService>()
                .To<ProgressService>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
        }

        private void BindAdsService()
        {
            Container
                .Bind<IAdsService>()
                .To<AdsService>()
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .FromSubContainerResolve()
                .ByInstaller<InputInstaller>()
                .AsSingle();
        }
    }
}