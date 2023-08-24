using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Pool.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Builder
{
    public class GenericPool<T> : IGenericPool<T> where T : MonoBehaviour 
    {
        private string _path;
        private Transform _parentTransform;
        
        private int _initialSize;
        private int _maxSize;
        private bool _expandByDoubling;

        private readonly ILocalFactory<T> _localFactory;
        private readonly Queue<T> _objectsQueue = new();

        public GenericPool(ILocalFactory<T> localFactory) => 
            _localFactory = localFactory;

        public GenericPool<T> SetPrefabResource(string path)
        {
            _path = path;
            return this;
        }

        public GenericPool<T> SetInitialSize(int size)
        {
            _initialSize = size;
            return this;
        }
        public GenericPool<T> SetMaxSize(int size)
        {
            _maxSize = size;
            return this;
        }

        public GenericPool<T> ExpandByDoubling(bool expandByDoubling)
        {
            _expandByDoubling = expandByDoubling;
            return this;
        }

        public GenericPool<T> UnderTransformGroup(Transform parent)
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
            if (TryGetFreeElement(out T obj))
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                if (_objectsQueue.Count <= 1)
                {
                    ExpandByDoubling();
                    return _objectsQueue.Dequeue();
                }
                else
                {
                    return CreateObject();
                }
            }
        }

        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
            _objectsQueue.Enqueue(obj);
        }

        
        private T CreateObject()
        {
            T obj = _localFactory.Create(_path, _parentTransform);
            obj.gameObject.SetActive(false);
            _objectsQueue.Enqueue(obj);
            return obj;
        }
        
        private bool TryGetFreeElement(out T element)
        {
            foreach (var obj in _objectsQueue)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    element = obj;
                    return true;
                }
            }
            element = null;
            return false;
        }
        
        private void ExpandByDoubling()
        {
            if (_expandByDoubling && _maxSize > _objectsQueue.Count)
            {
                int newSize = Mathf.Min(_maxSize, _objectsQueue.Count * 2);

                for (int i = _objectsQueue.Count; i < newSize; i++) 
                    CreateObject();
            }
        }
    }
}