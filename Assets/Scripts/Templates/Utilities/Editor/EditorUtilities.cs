using Templates.Saves;
using UnityEditor;
using UnityEngine;

namespace Templates.Utilities.Editor
{
    public static class EditorUtilities
    {
        [MenuItem("Dev/Save Assets")]
        private static void SaveAssets()
        {
            AssetDatabase.SaveAssets();
        }

        [MenuItem("Dev/Open Persistent Data Path")]
        private static void OpenPersistentDataPath()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }
        
        [MenuItem("Dev/Clear All Save")]
        private static void ClearAllSave()
        {
            ClearCurrenciesSave();
            ClearSkillTreeSave();
        }
        
        [MenuItem("Dev/Clear Currencies Save")]
        private static void ClearCurrenciesSave()
        {
            BinarySerialization.Delete("currencies");
        }
        
        [MenuItem("Dev/Clear Skill Tree Save")]
        private static void ClearSkillTreeSave()
        {
            BinarySerialization.Delete("skillTree");
        }
    }
}