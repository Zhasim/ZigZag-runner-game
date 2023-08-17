using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Builder
{
    public interface IPoolBuilder<T> where T : MonoBehaviour
    {
        void Initialize();
        T Rent();
        void Return(T obj);
        PoolBuilder<T> SetPrefabResource(string path);
        PoolBuilder<T> SetInitialSize(int size);
        PoolBuilder<T> SetMaxSize(int size);
        PoolBuilder<T> ExpandByDoubling(bool expandByDoubling);
        PoolBuilder<T> UnderTransformGroup(Transform parent);
    }
}