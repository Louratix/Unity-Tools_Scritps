using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnvironmentData
{
    public Material skyboxMaterial;
}

[System.Serializable]
static public class SavedData
{
    static EnvironmentData EnvironmentData;
    static public string savepath = "Assets/Edouard/Tools/DayNightTool/SavedSettings/";
    public static void Save(string Name)
    {
        EnvironmentData = new EnvironmentData();
        EnvironmentData.skyboxMaterial = RenderSettings.skybox;
        savepath += Name + "/";
        string savePlayerData = JsonUtility.ToJson(EnvironmentData);
        File.WriteAllText(savepath + Name + ".json", savePlayerData);
        savepath = "Assets/Edouard/Tools/DayNightTool/SavedSettings/";
    }

    
}
