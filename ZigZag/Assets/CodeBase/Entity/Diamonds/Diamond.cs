using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Diamonds
{
    public class Diamond : MonoBehaviour
    {
        public class Pool : MonoMemoryPool<Diamond>
        {
            
        }
    }
}