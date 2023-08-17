namespace CodeBase.Logic.TileGeneration.Generator
{
    public interface ITileGenerator
    {
        void StartGeneration();
        void StopGeneration();
        void PauseGeneration();
        void ResumeGeneration();
    }
}