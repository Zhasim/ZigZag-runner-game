using CodeBase.DI;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer();
        GameObject CreateInitPlatform();
        GameObject CreateDiamond();
        GameObject CreateBlock();
        void CreateBlockPool();
    }
}