using System;

namespace CodeBase.Data
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