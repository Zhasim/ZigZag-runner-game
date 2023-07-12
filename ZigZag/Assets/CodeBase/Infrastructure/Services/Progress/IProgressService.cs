using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress
{
    public interface IProgressService
    {
        OverallProgress Progress { get; set; }
    }
}