using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools.BlockPool
{
    public class BlockPool : IBlockPool
    {
        private readonly IGameFactory _factory;
        private Queue<GameObject> _pool = new();

        public BlockPool(IGameFactory factory) => 
            _factory = factory;

        public GameObject GetFreeElement()  
        {  
            if (HasFreeElement(out var element))  
                return element;  
            return CreateObject();  
        }

        public void CreatePool(int count)  
        {  
            _pool = new Queue<GameObject>();  
            for (int i = 0; i < count; i++) 
                CreateObject();
        }

        public void CleanUp() => 
            _pool.Clear();

        private bool HasFreeElement(out GameObject element)  
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
  
        private GameObject CreateObject()  
        {  
            var createdObject = _factory.CreateBlock();  
            createdObject.gameObject.SetActive(false);  
            _pool.Enqueue(createdObject);  
            return createdObject;  
        }  
    }
}