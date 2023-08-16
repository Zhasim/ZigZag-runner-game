using CodeBase.Entity.Player;
using CodeBase.Logic.Camera;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.DI.MonoInstallers
{
    public class GameLoopInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstantiateInitPlatform();
            InstantiatePlayer();
        }
        
        private void InstantiateInitPlatform()
        {
            Container
                .InstantiatePrefabResource(ResourcePath.INIT_PLATFORM);
            Container
                .InstantiatePrefabResource(ResourcePath.BLOCK);
            Container
                .InstantiatePrefabResource(ResourcePath.DIAMOND);
        }

        private void InstantiatePlayer()
        {
            GameObject player = Container
                .InstantiatePrefabResource(ResourcePath.PLAYER);
            PlayerDeath playerDeath = player.GetComponent<PlayerDeath>();
            
            CameraFollow(target: player);
        }
        
        private void CameraFollow(GameObject target)
        {
            if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().Follow(target);
        }
    }
}