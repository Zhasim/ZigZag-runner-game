using CodeBase.Data;
using CodeBase.DI;

namespace CodeBase.Infrastructure.Services.Progress
{
    public interface IProgressService : IService
    {
        OverallProgress Progress { get; set; }
    }
}