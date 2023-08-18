using System;
using CodeBase.Data.GameLoopData;

namespace CodeBase.Data
{
    [Serializable]
    public class OverallProgress
    {
        public WorldData WorldData;

        public OverallProgress()
        {
            WorldData = new WorldData();
        }
    }
}