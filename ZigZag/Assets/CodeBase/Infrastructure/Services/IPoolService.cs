using CodeBase.DI;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface IPoolService : IService
    {
        GameObject GetFreeElement();
    }
}