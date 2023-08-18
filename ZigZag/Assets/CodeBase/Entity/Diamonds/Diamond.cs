using CodeBase.Data;
using CodeBase.Data.GameLoopData;
using CodeBase.Data.GameLoopData.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using CodeBase.Tools;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Diamonds
{
    public class Diamond : PoolableObject, IProgressWriter
    {
        private const string PlayerTag = "Player";
        
        [SerializeField] private DropZone _dropZone;
        [SerializeField] private FallZone _fallZone;
        
        private IDiamondsPool _pool;
        private WorldData _worldData;
        
        private bool _dropped;
        private string _id;

        protected override float DelayBeforeReturning => 1.0f;
        protected override float DelayBeforeFalling => 0.3f;
        
        [Inject]
        public void Construct(IDiamondsPool pool) => 
            _pool = pool;

        public void Init(WorldData worldData) =>
            _worldData = worldData;

        protected override void Start()
        {
            base.Start();
            _id = GetComponent<UniqueId>().Id;
            _dropZone.TriggerEnter += OnTriggerEntered;
            _fallZone.TriggerExit += OnTriggerExited;
        }

        private void OnDestroy()
        {
            _dropZone.TriggerEnter -= OnTriggerEntered;
            _fallZone.TriggerExit -= OnTriggerExited;
        }

        public void WriteProgress(OverallProgress progress)
        {
            if(_dropped)
                return;
            
            DiamondsDataDictionary diamondsOnScene = progress.WorldData.DiamondsData.DiamondsOnScene;

            if (!diamondsOnScene.Dictionary.ContainsKey(_id))
                diamondsOnScene.Dictionary
                    .Add(_id, new DiamondsPositionData(transform.position.AsVector3Data()));
        }

        private void OnTriggerEntered(Collider obj)
        {
            if(_dropped)
                return;
            
            if (obj.CompareTag(PlayerTag))
            {
                Collect();
                ReturnToPool();
            }
        }

        private void OnTriggerExited(Collider obj)
        {
            if(_dropped)
                return;

            if (!_dropped) 
                StartCoroutine(WaitAndFallDown());
        }

        private void Collect()
        {
            _dropped = true;
            _worldData.DiamondsData.Collect();
            RemoveFromDiamondsOnScene();
        }
        
        private void RemoveFromDiamondsOnScene()
        {
            DiamondsDataDictionary diamondsOnScene = _worldData.DiamondsData.DiamondsOnScene;

            if (diamondsOnScene.Dictionary.ContainsKey(_id))
                diamondsOnScene.Dictionary.Remove(_id);
        }

        protected override void ReturnToPool() => 
            _pool.ReturnDiamond(this);
    }
}