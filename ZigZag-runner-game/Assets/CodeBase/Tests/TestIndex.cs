using UnityEngine;

namespace CodeBase.Tests
{
    public class TestIndex : MonoBehaviour
    {
        public Transform popUpInventory;
        public Transform popUpShop;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                ShopPopUp(popUpShop);
            if (Input.GetKeyDown(KeyCode.D))
                ShopPopUp(popUpInventory);
        }

        private void ShopPopUp(Transform window)
        {
            window.gameObject.SetActive(true);
            window.SetAsLastSibling();
        }
    }
}