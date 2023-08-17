namespace CodeBase.Logic.TileGeneration.Creator
{
    public interface ITileCreator
    {
        void Init();
        void CreateTile();
        bool IsSpawning { get; set; }
    }
}