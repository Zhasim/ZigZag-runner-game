using UnityEngine;
using Zenject;

namespace CodeBase.Entity
{
    public class Block : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<Block>
        {
        }
    }
}