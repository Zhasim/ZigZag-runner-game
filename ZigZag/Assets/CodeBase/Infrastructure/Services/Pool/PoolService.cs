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
            return null;
            //throw new Exception($"There is no free element in pool of type Block");
        }

        public GameObject GetFreeDiamond()
        {
            if (HasFreeElement(out GameObject element, DiamondsPool))
                return element;
            
            throw new Exception($"There is no free element in pool of type Block");
        }

        public void CleanUp()
        {
            BlocksPool.Clear();
            DiamondsPool.Clear();
        }

        public void AddBlockToPool(GameObject element)
        {
            element.gameObject.SetActive(false);
            BlocksPool.Add(element);
        }

        public void AddDiamondToPool(GameObject element)
        {
            element.gameObject.SetActive(false);
            DiamondsPool.Add(element);
        }

        private bool HasFreeElement(out GameObject element, List<GameObject> pool)
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