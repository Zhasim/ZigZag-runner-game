using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Logic.Camera;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.MonoInstallers
{
    public class InitGameLoopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInitPlatform();
            BindPlayer();
        }

        private void BindInitPlatform()
        {
            Container
                .InstantiatePrefabResource(AssetPath.INIT_PLATFORM);
            Container
                .InstantiatePrefabResource(AssetPath.BLOCK);
            Container
                .InstantiatePrefabResource(AssetPath.DIAMOND);
        }

        private void BindPlayer()
        {
            GameObject player = Container
                .InstantiatePrefabResource(AssetPath.PLAYER);
            
            CameraFollow(player);
        }
        
        private static void CameraFollow(GameObject hero)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}