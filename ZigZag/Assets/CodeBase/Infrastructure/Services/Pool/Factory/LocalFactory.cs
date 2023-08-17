using CodeBase.Infrastructure.ResourceLoad;
using UnityEngine;
using Zenject;
using ILogger = CodeBase.Infrastructure.Services.CustomLogger.ILogger;

namespace CodeBase.Infrastructure.Services.Pool.Factory
{
    public class LocalFactory<T> : ILocalFactory<T> where T : MonoBehaviour
    {
        private readonly IResourceLoader _resourceLoader;
        private readonly IInstantiator _instantiator;
        private readonly ILogger _logger;

        public LocalFactory(IResourceLoader resourceLoader, 
            IInstantiator instantiator,
            ILogger logger)
        {
            _resourceLoader = resourceLoader;
            _instantiator = instantiator;
            _logger = logger;
        }

        public T Create(string path, Transform container)
        {
            GameObject prefab = _resourceLoader.Load(path);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, container);

            T component = instance.GetComponent<T>();
            if (component == null)
                _logger.LogError($"Component of type {typeof(T).Name} not found on the instantiated object.");
            
            return component;
        }
    }
}