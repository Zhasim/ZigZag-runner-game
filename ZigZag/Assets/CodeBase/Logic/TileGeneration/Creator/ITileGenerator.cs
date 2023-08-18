namespace CodeBase.Logic.TileGeneration.Creator
{
    public interface ITileGenerator
    {
        void Init();
        void CreateTile();
        bool IsSpawning { get; set; }
    }
}