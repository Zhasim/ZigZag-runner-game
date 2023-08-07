using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Vector3 at);
        GameObject CreateInitPlatform(Vector3 at);
        GameObject CreateDiamond(Vector3 at);
        GameObject CreateBlock(Vector3 at);
    }
}