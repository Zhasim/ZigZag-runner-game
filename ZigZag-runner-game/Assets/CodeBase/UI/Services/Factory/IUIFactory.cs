namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory
    {
        void CreateUIRoot();
        void CreateLoseScreen();
        void CreatePauseScreen();
        void CreateSettingsScreen();
        void CreateLeaveScreen();
        void CreateRankingScreen();
    }
}