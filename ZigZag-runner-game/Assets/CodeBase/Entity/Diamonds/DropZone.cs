using System;
using UnityEngine;

namespace CodeBase.Entity.Diamonds
{
    [RequireComponent(typeof(Collider))]
    public class DropZone : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        private void OnTriggerEnter(Collider other) => 
            TriggerEnter?.Invoke(other);
    }
}