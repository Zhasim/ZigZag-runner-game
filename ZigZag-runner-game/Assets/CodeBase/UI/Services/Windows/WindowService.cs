using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Factory;

namespace CodeBase.UI.Services.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Open(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.Unknown:
                    break;
                case WindowId.Lose:
                    _uiFactory.CreateLoseScreen();
                    break;
                case WindowId.Pause:
                    _uiFactory.CreatePauseScreen();
                    break;
                case WindowId.Settings:
                    _uiFactory.CreateSettingsScreen();
                    break;
                case WindowId.Leave:
                    _uiFactory.CreateLeaveScreen();
                    break;
                case WindowId.Ranking:
                    _uiFactory.CreateRankingScreen();
                    break;
            }
        }
    }
}