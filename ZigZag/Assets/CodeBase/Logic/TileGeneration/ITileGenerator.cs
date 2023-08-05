using System.Collections;

namespace CodeBase.Logic.TileGeneration
{
    public interface ITileGenerator
    {
        void Init();
        bool IsSpawning { get; set; }
        IEnumerator StartSpawnRepeater();
    }
}