using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools.DiamondPool
{
    public interface IDiamondPool
    {
        GameObject GetFreeElement();
        void CreatePool(int count);
        void CleanUp();
    }
}