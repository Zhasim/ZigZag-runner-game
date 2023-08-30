using System;
using CodeBase.UI.Windows;
using UnityEngine.Serialization;

namespace CodeBase.StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}