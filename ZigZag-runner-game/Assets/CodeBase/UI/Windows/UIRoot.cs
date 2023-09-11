using UnityEngine;

namespace CodeBase.UI.Windows
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Transform _popLayer;
        public Transform PopLayer => _popLayer;
    }
}