using CodeBase.Data.GameLoopData;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration.Creator
{
    public interface ITileGenerator
    {
        void Init(WorldData worldData, Transform playerTransform);
        void HandlePlayerInput();
    }
}