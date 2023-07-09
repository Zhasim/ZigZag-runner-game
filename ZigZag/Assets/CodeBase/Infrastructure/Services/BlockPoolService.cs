using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class BlockPoolService : IPoolService
    {
        private readonly IGameFactory _factory;
        private readonly int _count;
        private readonly GameObject _prefab;

        private Transform _container;
        private bool _autoExpand;
        private Stack<GameObject> _pool;
        
        public BlockPoolService(GameObject prefab, int count, Transform container, IGameFactory factory)
        {
            _prefab = prefab;
            _count = count;
            _container = container;
            _factory = factory;
            
            CreatePool(count);
        }

        public GameObject GetFreeElement()
        {
            if (HasFreeElement(out GameObject element))
                return element;

            if (_autoExpand)
            {
                PoolExpansion();
                return CreateObject();
            }

            throw new Exception($"There is no free element in pool of type Block");
        }

        private void CreatePool(int count)
        {
            _pool = new Stack<GameObject>();
            
            for (int i = 0; i < count; i++) 
                CreateObject();
        }


        private bool HasFreeElement(out GameObject element)
        {
            foreach (GameObject obj in _pool)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    element = obj;
                    obj.gameObject.SetActive(true);
                    return true;
                }
            }
            
            element = null;
            return false;
        }

        private void PoolExpansion()
        {
            for (int i = 0; i < _count * Constants.POOL_MULTIPLIER; i++)
                CreateObject();
        }

        private GameObject CreateObject()
        {
            GameObject createObject = _factory.CreateBlock();
            createObject.gameObject.SetActive(false);
            _pool.Push(createObject);
            
            return createObject;
        }
    }
}