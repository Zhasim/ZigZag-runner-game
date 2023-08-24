using System;
using CodeBase.Data.GameLoopData.Entity.Diamonds;

namespace CodeBase.Data.GameLoopData
{
    [Serializable]
    public class WorldData
    {
        public DiamondsData DiamondsData;
  
        public WorldData()
        {
            DiamondsData = new DiamondsData();
  }
    }
}