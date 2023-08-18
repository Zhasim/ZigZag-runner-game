using UnityEngine;

namespace CodeBase.Logic.TileGeneration.Creator
{
    public interface ITileGenerator
    {
        void Init(Transform playerTransform);
        void HandlePlayerInput();
    }
}