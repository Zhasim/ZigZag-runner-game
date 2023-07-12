using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.MonoInstallers.ProjectContext
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            BindInputService();

        private void BindInputService()
        {
            if (Application.isEditor)
                BindStandaloneInputService();
            else
                BindMobileInputService();
        }
        
        private void BindStandaloneInputService()
        {
            Container
                .Bind<IInputService>()
                .To<StandaloneInputService>()
                .AsSingle();
            Debug.Log("INPUT - STANDALONE");
        }
        
        private void BindMobileInputService()
        {
            Container
                .Bind<IInputService>()
                .To<MobileInputService>()
                .AsSingle();
            
            Debug.Log("INPUT - MOBILE");
        }
    }
}