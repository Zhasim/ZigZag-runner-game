using CodeBase.DI;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateWinScreen();
        void CreateLoseScreen();
        void CreateUIRoot();
    }
}