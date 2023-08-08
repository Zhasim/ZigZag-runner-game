using System;
using UnityEngine;

namespace CodeBase.Entity.Diamonds
{
    [RequireComponent(typeof(Collider))]
    public class FallZone : MonoBehaviour
    {
        public event Action<Collider> TriggerExit;
        private void OnTriggerExit(Collider other) =>
            TriggerExit?.Invoke(other);
    }
}