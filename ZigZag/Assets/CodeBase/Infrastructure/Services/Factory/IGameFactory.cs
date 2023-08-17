using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IGameFactory
    {
        GameObject CreatePlayer(Vector3 at, Transform container);
        GameObject CreateInitPoint(Transform container);
        GameObject CreateInitPlatform(Transform parent);
    }
}