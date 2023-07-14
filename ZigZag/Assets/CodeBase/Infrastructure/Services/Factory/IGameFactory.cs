using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory
    {
        GameObject CreatePlayer();
        GameObject CreateInitPlatform();
        GameObject CreateDiamond();
        GameObject CreateBlock();
    }
}