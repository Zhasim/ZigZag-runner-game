using CodeBase.DI;
using CodeBase.StaticData.Windows;

namespace CodeBase.UI.Services.Windows
{
    public interface IWindowService : IService
    {
        void Open(WindowId windowId);
    }
}