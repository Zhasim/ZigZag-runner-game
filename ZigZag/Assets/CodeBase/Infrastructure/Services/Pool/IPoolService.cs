using System.Collections.Generic;
using CodeBase.DI;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool
{
    public interface IPoolService : IService
    {
        List<GameObject> BlocksPool { get; }
        List<GameObject> DiamondsPool { get; }
        GameObject GetFreeBlock();
        GameObject GetFreeDiamond();
        void CleanUp();
        void AddBlockToPool(GameObject obj);
        void AddDiamondToPool(GameObject obj);
    }
}