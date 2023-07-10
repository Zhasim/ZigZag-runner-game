using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool
{
    public class PoolService : IPoolNewService
    {
        public List<GameObject> pool { get; } = new();
        
        public GameObject GetFreeElement()
        {
            if (HasFreeElement(out GameObject element))
                return element;
            
            throw new Exception($"There is no free element in pool of type Block");
        }

        public void AddElementToPool(GameObject element)
        {
            element.gameObject.SetActive(false);
            pool.Add(element);
        }

        public void CleanUp() => 
            pool.Clear();

        private bool HasFreeElement(out GameObject element)
        {
            foreach (GameObject obj in pool)
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
    }
}