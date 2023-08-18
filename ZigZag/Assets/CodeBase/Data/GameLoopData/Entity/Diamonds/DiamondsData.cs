using System;

namespace CodeBase.Data.GameLoopData.Entity.Diamonds
{
    [Serializable]
    public class DiamondsData
    {
        public DiamondsDataDictionary DiamondsOnScene = new ();
        public int Collected;
        public Action Changed;
        
        public void Collect()
        {
            Collected++;
            Changed?.Invoke();
        }
    }
}