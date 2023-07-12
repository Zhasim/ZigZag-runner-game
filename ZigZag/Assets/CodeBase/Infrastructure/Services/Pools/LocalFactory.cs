using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools
{
    public class LocalFactory<T> : ILocalFactory<T> where T : MonoBehaviour
    {
        private readonly T _prefab;  
        public LocalFactory(T prefab) =>   
            _prefab = prefab;  
  
        public T Create()  
        {  
            T instance = Object.Instantiate(_prefab);  
            return instance;  
        }  
    }
}