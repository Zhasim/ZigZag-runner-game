using CodeBase.Data;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class DiamondsCounter : MonoBehaviour
    {
        public TextMeshProUGUI Counter;
        private WorldData _worldData;

        public void Construct(WorldData worldData)
        {
            _worldData = worldData;
            _worldData.DiamondsData.Changed += UpdateCounter;
            
            UpdateCounter();
        }
        
        private void UpdateCounter()
        {
            Counter.text = $"{_worldData.DiamondsData.Collected}";
        }
    }
}