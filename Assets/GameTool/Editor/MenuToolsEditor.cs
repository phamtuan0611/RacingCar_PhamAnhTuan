using UnityEditor;

namespace GameTool.Editor
{
    public class MenuToolsEditor
    {
        [MenuItem("MenuTools/Data/ClearData")]
        public static void ClearData()
        {
            GameData.Instance.ClearAllData();
        }
        
        [MenuItem("MenuTools/Data/SaveData")]
        public static void SaveData()
        {
            GameData.Instance.SaveAllData();
        }
        
        [MenuItem("MenuTools/Data/LoadData")]
        public static void LoadData()
        {
            GameData.Instance.LoadAllData();
        }
    }
}