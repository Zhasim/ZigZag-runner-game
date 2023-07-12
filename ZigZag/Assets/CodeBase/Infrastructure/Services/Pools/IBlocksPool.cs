using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools
{
    public interface IBlocksPool
    {
        GameObject GetFreeElement();
        void CreatePool(int count);
        void CleanUp();
    }
}