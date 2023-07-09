using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool
{
    public class PoolService : IPoolService
    {
        public List<GameObject> BlocksPool { get; } = new();
        public List<GameObject> DiamondsPool { get; } = new();
        
        public GameObject GetFreeBlock()
        {
            if (HasFreeElement(out GameObject element, BlocksPool))
                return element;
            
            throw new Exception($"There is no free element in pool of type Block");
        }
        public GameObject GetFreeDiamond()
        {
            if (HasFreeElement(out GameObject element, DiamondsPool))
                return element;
            
            throw new Exception($"There is no free element in pool of type Diamond");
        }

        public void CleanUp()
        {
            BlocksPool.Clear();
            DiamondsPool.Clear();
        }
        
        private bool HasFreeElement(out GameObject element, List<GameObject> list)
        {
            foreach (GameObject obj in list)
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
        
        public void AddBlockToPool(GameObject obj)
        {
            obj.gameObject.SetActive(false);
            BlocksPool.Add(obj);
        }

        public void AddDiamondToPool(GameObject obj)
        {
            obj.gameObject.SetActive(false);
            DiamondsPool.Add(obj);
        }
    }
}