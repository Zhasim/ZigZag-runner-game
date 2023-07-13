using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.Infrastructure.Services.Registration;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using Zenject;

namespace CodeBase.DI.MonoInstallers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindRandomService();
            
            BindStaticDataService();   
            
            BindProgressService();
            
            BindRegistrationService();
            
            BindSaveLoadService();
            
            BindAdsService();
        }
        
        private void BindStaticDataService()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
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
        
        private void BindRegistrationService()
        {
            Container
                .Bind<IRegistrationService>()
                .To<RegistrationService>()
                .AsSingle();
        }
    }
}