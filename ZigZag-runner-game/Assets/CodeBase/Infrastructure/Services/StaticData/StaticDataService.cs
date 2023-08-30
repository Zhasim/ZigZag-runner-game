using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataWindows = "StaticData/UI/WindowStaticData";
        
        private Dictionary<WindowId,WindowConfig> _windowConfigs;

        public void Load()
        {
            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindows)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
        }
        
        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig) 
                ? windowConfig 
                : null;
    }
}