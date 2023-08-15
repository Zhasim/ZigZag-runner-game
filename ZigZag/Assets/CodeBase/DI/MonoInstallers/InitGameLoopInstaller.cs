using CodeBase.Entity.Player;
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
            InstantiateSaver();
            InstantiateInitPlatform();
            //InstantiatePlayer();
        }
        
        private void InstantiateSaver()
        {
            Container
                .InstantiatePrefabResource(AssetPath.SAVER);
        }

        private void InstantiateInitPlatform()
        {
            Container
                .InstantiatePrefabResource(AssetPath.INIT_PLATFORM);
            Container
                .InstantiatePrefabResource(AssetPath.BLOCK);
            Container
                .InstantiatePrefabResource(AssetPath.DIAMOND);
        }

        // private void InstantiatePlayer()
        // {
        //     GameObject player = Container
        //         .InstantiatePrefabResource(AssetPath.PLAYER);
        //     PlayerDeath playerDeath = player.GetComponent<PlayerDeath>();
        //     
        //     CameraInit(playerDeath, target: player);
        // }
        
        // private void CameraInit(PlayerDeath player, GameObject target)
        // {
        //     if (Camera.main != null) Camera.main.GetComponent<CameraFollow>().InitFollow(player, target);
        // }
    }
}