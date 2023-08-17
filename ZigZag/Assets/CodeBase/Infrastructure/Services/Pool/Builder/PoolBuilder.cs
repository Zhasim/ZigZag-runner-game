using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Pool.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Builder
{
    public class PoolBuilder<T> : IPoolBuilder<T> where T : MonoBehaviour 
    {
        private string _path;
        private Transform _parentTransform;
        
        private int _initialSize;
        private int _maxSize;
        private bool _expandByDoubling;

        private readonly ILocalFactory<T> _localFactory;
        private readonly Queue<T> objectQueue = new();

        public PoolBuilder(ILocalFactory<T> localFactory) => 
            _localFactory = localFactory;

        public PoolBuilder<T> SetPrefabResource(string path)
        {
            _path = path;
            return this;
        }

        public PoolBuilder<T> SetInitialSize(int size)
        {
            _initialSize = size;
            return this;
        }

        public PoolBuilder<T> SetMaxSize(int size)
        {
            _maxSize = size;
            return this;
        }

        public PoolBuilder<T> ExpandByDoubling(bool expandByDoubling)
        {
            _expandByDoubling = expandByDoubling;
            return this;
        }

        public PoolBuilder<T> UnderTransformGroup(Transform parent)
        {
            _parentTransform = parent;
            return this;
        }

        public void Initialize()
        {
            for (int i = 0; i < _initialSize; i++) 
                CreateObject();
        }

        public T Rent()
        {
            if (objectQueue.Count == 0)
            {
                if (_expandByDoubling && objectQueue.Count < _maxSize)
                {
                    int newSize = Mathf.Min(_maxSize - objectQueue.Count, objectQueue.Count);
                    for (int i = 0; i < newSize; i++) 
                        CreateObject();
                }
                else
                {
                    Debug.LogWarning("CustomObjectPool is empty and cannot expand further.");
                    return null;
                }
            }

            T obj = objectQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
            objectQueue.Enqueue(obj);
        }

        private T CreateObject()
        {
            T obj = _localFactory.Create(_path, _parentTransform);
            obj.gameObject.SetActive(false);
            objectQueue.Enqueue(obj);
            return obj;
        }
    }
}