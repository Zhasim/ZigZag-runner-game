using CodeBase.DI;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer();
        GameObject CreateInitPlatform();
        GameObject CreateDiamond();
        GameObject CreateBlock();
    }
}