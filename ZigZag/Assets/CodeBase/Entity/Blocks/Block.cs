using CodeBase.Infrastructure.Services.Pool.Pools;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Blocks
{
    public class Block : PoolableObject
    {
        protected override float DelayBeforeReturning => 2f;
        protected override float DelayBeforeFalling => 0.1f;
        
        private IBlocksPool _pool;

        [Inject]
        public void Construct(IBlocksPool pool) => 
            _pool = pool;
        
        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
                StartCoroutine(WaitAndFallDown());
        }
        
        protected override void ReturnToPool() => 
            _pool.ReturnBlock(this);
    }
}