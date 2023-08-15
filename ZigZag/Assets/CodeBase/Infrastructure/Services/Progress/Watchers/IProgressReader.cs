using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Watchers
{
    public interface IProgressReader : IProgressWriter
    {
        void ReadProgress(OverallProgress progress);
    }
}