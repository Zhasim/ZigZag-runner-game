using UnityEngine;

namespace CodeBase.Entity.Diamonds
{
    public class Diamond : MonoBehaviour
    {
        public bool pickedUp;
        private void OnTriggerEnter(Collider other)
        {
            pickedUp = true;
            if (other.CompareTag("Player"))
                BackInPool();
        }

        private void BackInPool()
        {
            pickedUp = false;
            gameObject.SetActive(false);
        }
    }
}