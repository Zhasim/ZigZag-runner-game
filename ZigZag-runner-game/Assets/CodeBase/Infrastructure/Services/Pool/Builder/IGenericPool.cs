using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Builder
{
    public interface IGenericPool<T> where T : MonoBehaviour
    {
        void Initialize();
        T Rent();
        void Return(T obj);
        GenericPool<T> SetPrefabResource(string path);
        GenericPool<T> SetInitialSize(int size);
        GenericPool<T> SetMaxSize(int size);
        GenericPool<T> ExpandByDoubling(bool expandByDoubling);
        GenericPool<T> UnderTransformGroup(Transform parent);
    }
}