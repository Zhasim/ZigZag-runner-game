using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.Installers
{
    public class InputInstaller : Installer<InputInstaller>
    {
        public override void InstallBindings() => 
            BindInputService();

        private void BindInputService()
        {
            if (Application.isEditor)
            {
                BindStandaloneInputService();
                Debug.Log("INPUT - STANDALONE");
            }
            else
            {
                BindMobileInputService();
                Debug.Log("INPUT - MOBILE");
            }
        }
        
        private void BindStandaloneInputService()
        {
            Container
                .Bind<IInputService>()
                .To<StandaloneInputService>()
                .AsSingle();
        }
        
        private void BindMobileInputService()
        {
            Container
                .Bind<IInputService>()
                .To<MobileInputService>()
                .AsSingle();
        }

    }
}