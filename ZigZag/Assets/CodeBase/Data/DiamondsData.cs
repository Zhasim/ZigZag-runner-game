using System;

namespace CodeBase.Data
{
    [Serializable]
    public class DiamondsData
    {
        public int Collected;
        public Action Changed;
        
        public void Collect()
        {
            Collected++;
            Changed?.Invoke();
        }
    }
}