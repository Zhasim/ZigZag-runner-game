using CodeBase.StaticData.Windows;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        WindowConfig ForWindow(WindowId windowId);
    }
}