using CodeBase.Data;
using CodeBase.DI;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        OverallProgress LoadProgress();
    }
}