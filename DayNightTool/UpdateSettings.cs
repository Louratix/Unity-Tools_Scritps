using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UpdateSettings : MonoBehaviour
{
    static public void UpdateSetting(string Name)
    {
        string PathSkybox = "Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name + "/" + Name +".mat";
        Material Current_skybox = RenderSettings.skybox;
        Material Saved_Skybox = Instantiate(Current_skybox);
        AssetDatabase.DeleteAsset(PathSkybox); 
        AssetDatabase.CreateAsset(Saved_Skybox, PathSkybox);
    }
}
