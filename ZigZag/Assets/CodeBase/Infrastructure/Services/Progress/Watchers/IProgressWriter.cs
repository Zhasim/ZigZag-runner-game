using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Watchers
{
    public interface IProgressWriter
    {
        void WriteProgress(OverallProgress progress);
    }
}