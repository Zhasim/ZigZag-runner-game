using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Pool;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        private IPoolService _poolService;

        public void Construct(IPoolService poolService) => 
             _poolService = poolService;

        private void Update()
         {
             if (Input.GetKeyDown(KeyCode.A))
             {
                 _poolService.GetFreeBlock();
                 Debug.Log("Tried get element");
             }
         }
    }
}