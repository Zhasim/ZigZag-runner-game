using UnityEditor;
using UnityEditor.SceneManagement;

namespace CodeBase.Editor.Tools
{
    public static class AutoSaveTool
    {
        [MenuItem("Tools/Enable Auto Save")]
        public static void EnableAutoSave()
        {
            EditorApplication.playModeStateChanged += AutoSaveOnPlayModeChanged;
        }

        [MenuItem("Tools/Disable Auto Save")]
        public static void DisableAutoSave()
        {
            EditorApplication.playModeStateChanged -= AutoSaveOnPlayModeChanged;
        }

        private static void AutoSaveOnPlayModeChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.ExitingPlayMode)
            {
                EditorSceneManager.SaveOpenScenes();
            }
        }
    }
}