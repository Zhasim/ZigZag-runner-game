using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools.BlockPool
{
    public interface IBlockPool
    {
        GameObject GetFreeElement();
        void CreatePool(int count);
        void CleanUp();
    }
}