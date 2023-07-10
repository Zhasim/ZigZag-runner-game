using CodeBase.Infrastructure.Services.Pool;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        //private IPoolService _poolService;
        private IPoolNewService _blockPool;
        private IPoolNewService _diamondPool;

        public void Construct(IPoolNewService blockPool, IPoolNewService diamondPool)
        {
            _blockPool = blockPool;
            _diamondPool = diamondPool;
        }
        // public void Construct(IPoolService poolService) => 
        //      _poolService = poolService;

        private void Update()
         {
             // if (Input.GetKeyDown(KeyCode.A))
             // {
             //     _poolService.GetFreeBlock();
             //     Debug.Log("Tried get element");
             // }
             
             if (Input.GetKeyDown(KeyCode.D))
             {
                 _blockPool.GetFreeElement();
                 Debug.Log("Tried get element");
             }
             if (Input.GetKeyDown(KeyCode.A))
             {
                 _diamondPool.GetFreeElement();
                 Debug.Log("Tried get element");
             }
             
             
         }
    }
}