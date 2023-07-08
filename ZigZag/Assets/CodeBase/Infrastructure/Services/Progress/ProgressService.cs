using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.Progress
{
    public class ProgressService : IProgressService
    {
        public OverallProgress Progress { get; set; }
    }
}