using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools
{
    public class PoolMono<T> where T : MonoBehaviour    
    {
        public T _prefab { get; }  
        public Transform _container { get; }  
  
        private ILocalFactory<T> _localFactory;  
        private List<T> _pool;  
  
        public PoolMono(T prefab, int count, ILocalFactory<T> localFactory)  
        {  
            _prefab = prefab;  
            _container = null;  
            _localFactory = localFactory;  
            CreatePool(count);  
        }  
  
        public PoolMono(T prefab, int count, Transform container, ILocalFactory<T> localFactory)  
        {  
            _prefab = prefab;  
            _container = container;  
            _localFactory = localFactory;  
            CreatePool(count);  
        }

        public T GetFreeElement()  
        {  
            if (HasFreeElement(out var element))  
                return element;  
            return CreateObject(true);  
        }

        private void CreatePool(int count)  
        {  
            _pool = new List<T>();  
            for (int i = 0; i < count; i++)  
            {  
                CreateObject();  
            }  
        }

        private bool HasFreeElement(out T element)  
        {  
            foreach (var mono in _pool)  
            {  
                if (!mono.gameObject.activeInHierarchy)  
                {  
                    element = mono;  
                    mono.gameObject.SetActive(true);  
                    return true;  
                }  
            }  
            element = null;  
            return false;  
        }  
  
        private T CreateObject(bool isActiveByDefault = false)  
        {  
            var createdObject = _localFactory.Create();  
            createdObject.gameObject.SetActive(isActiveByDefault);  
            _pool.Add(createdObject);  
            return createdObject;  
        }  
    }
}