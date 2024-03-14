using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using GameTool;

[CustomEditor(typeof(GameData))]
public class GameDataEditor : Editor
{
    public override void OnInspectorGUI()
    {  
        GameData gameData = target as GameData;
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Load Data"))
            LoadData();

        if (GUILayout.Button("Save Data"))
            SaveData();
        
        if (GUILayout.Button("Clear Data"))
            ClearData();
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Update Script"))
        {
            //BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            //List<object> fieldValues = gameData.Data.GetType().GetFields(bindingFlags).Select(field => field.GetValue(gameData.Data)).ToList();
            
            string path = Application.dataPath + "/GameTool/Scripts/GameDataControl.cs";

            string pathEnum = Application.dataPath + "/GameTool/Scripts/eData.cs";

            List<string> fieldName = typeof(GameDataSave).GetFields().Select(field => field.Name).ToList();

            List<string> textEnum = new List<string>();
            textEnum.Add("namespace GameTool");
            textEnum.Add("{");
            textEnum.Add("    public enum eData");
            textEnum.Add("    {");
            textEnum.Add("        None,");
            
            List<string> texts = new List<string>();
            texts.Add("namespace GameTool");
            texts.Add("{");
            texts.Add("    public static class GameDataControl");
            texts.Add("    {");
            texts.Add("        public static void SaveAllData()");
            texts.Add("        {");

            foreach (string value in fieldName)
            {
                texts.Add(string.Format("            GameData.Instance.SaveData(eData.{0}, GameData.Instance.Data.{0});", value));
                textEnum.Add("        " + value + ",");
            }

            textEnum.Add("    }");
            textEnum.Add("}");

            texts.Add("        }");

            texts.Add("");

            texts.Add("        public static void LoadAllData()");
            texts.Add("        {");

            foreach (string value in fieldName)
            {
                texts.Add(string.Format("            GameData.Instance.LoadData(eData.{0}, ref GameData.Instance.Data.{0});", value));
            }

            texts.Add("        }");

            texts.Add("    }");

            texts.Add("}");

            File.WriteAllLines(path, texts.ToArray());
            File.WriteAllLines(pathEnum, textEnum.ToArray());
        }

        base.OnInspectorGUI();
    }

    public void SaveData()
    {
        GameData gameData = target as GameData;
        gameData.SaveAllData();
    }

    public void LoadData()
    {
        GameData gameData = target as GameData;
        gameData.LoadAllData();
    } 

    public void ClearData()
    {
        SaveGameManager.DeleteAllSave();
        GameData gameData = target as GameData;
        gameData.ClearAllData();
    }
}
