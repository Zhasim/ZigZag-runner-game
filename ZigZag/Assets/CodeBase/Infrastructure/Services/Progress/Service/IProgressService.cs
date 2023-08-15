using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress.Service
{
    public interface IProgressService
    {
        OverallProgress Progress { get; set; }
    }
}