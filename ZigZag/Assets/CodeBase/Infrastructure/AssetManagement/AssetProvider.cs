using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly IInstantiator _instantiator;
        public AssetProvider(IInstantiator instantiator) => 
            _instantiator = instantiator;

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            _instantiator.InstantiatePrefab(prefab);
            return prefab;
        }

        public GameObject InstantiateCheck(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            Object.Instantiate(prefab);
            return prefab;
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            GameObject prefab = _instantiator.InstantiatePrefabResource(path);
            prefab.transform.position = at;
            return prefab;
        }
        
        //var prefab = Resources.Load<GameObject>(path);
        //Object.Instantiate(prefab);
    }
}