using System;

namespace CodeBase.Data.GameLoopData.Entity.Diamonds
{
    [Serializable]
    public class DiamondsPositionData
    {
        public Vector3Data Position;

        public DiamondsPositionData(Vector3Data position) => 
            Position = position;
    }
}