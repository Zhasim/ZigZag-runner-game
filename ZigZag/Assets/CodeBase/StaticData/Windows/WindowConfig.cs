using System;
using CodeBase.UI.Windows;


namespace CodeBase.StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase prefab;
    }
}