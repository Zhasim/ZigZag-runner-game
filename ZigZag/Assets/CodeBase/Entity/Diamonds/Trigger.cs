using UnityEngine;

namespace CodeBase.Entity.Diamonds
{
    [RequireComponent(typeof(BoxCollider))]
    public class Trigger : MonoBehaviour
    {
        private Diamond _diamond;
        private bool exited;

        private void Start() => 
            _diamond = GetComponentInParent<Diamond>();

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                exited = true;
            if (!_diamond.pickedUp && exited)
            {
                Debug.Log("EXITED!");
            }
        }
    }
}