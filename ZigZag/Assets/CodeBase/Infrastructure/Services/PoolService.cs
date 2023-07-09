using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class PoolService : IPoolService
    {
        public List<GameObject> BlocksPool { get; } = new();
        public List<GameObject> DiamondsPool { get; } = new();
        

        public GameObject GetFreeBlock()
        {
            if (HasFreeElement(out GameObject element, BlocksPool))
                return element;
            
            // PoolExpansion(BlocksPool);
            // return AddObjectToPool();
            throw new Exception($"There is no free element in pool of type Block");
        }
        public GameObject GetFreeDiamond()
        {
            if (HasFreeElement(out GameObject element, DiamondsPool))
                return element;
            
            // PoolExpansion(DiamondsPool);
            // return AddObjectToPool();
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
        
        // private void PoolExpansion(List<GameObject> list)
        // {
        //     for (int i = 0; i < list.Count * Constants.POOL_MULTIPLIER; i++)
        //         AddObjectToPool();
        // }

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