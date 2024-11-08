using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEditor.SceneManagement;
using System.Reflection;
using UnityEditor.SearchService;
using System.IO;

public class SavingSettings : MonoBehaviour
{
    static LightingSettings Saved_SourceLightingSettings = default;
    static LightingSettings Current_SourceLightingSettings = default;
    static Material Current_skybox;
    static Material Saved_Skybox;

    static public void Save(string Name)
    {
        AssetDatabase.CreateFolder("Assets/Edouard/Tools/DayNightTool/SavedSettings", Name);
        string Path = "Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name + "/" + Name +".lighting";
        string PathSkybox = "Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name + "/" + Name +".mat";
        
        var activeScene = EditorSceneManager.GetActiveScene();

        if(Lightmapping.TryGetLightingSettings(out LightingSettings settings))
        {
            Current_SourceLightingSettings = Lightmapping.GetLightingSettingsForScene(activeScene); 
            Saved_SourceLightingSettings = Instantiate(Current_SourceLightingSettings);
            AssetDatabase.CreateAsset(Saved_SourceLightingSettings,Path);
        }
        else
        {
            LightingSettings lightingSettings = new LightingSettings();
            AssetDatabase.CreateAsset(lightingSettings,Path);
            Debug.LogErrorFormat("No Current Lightning Settings to save!");
        }

        if(RenderSettings.skybox)
        {
            Current_skybox = RenderSettings.skybox; 
            Saved_Skybox = Instantiate(Current_skybox);
            AssetDatabase.CreateAsset(Saved_Skybox,PathSkybox);
        }
        else
        {
            Debug.LogErrorFormat("No Current Lightning Settings to save!");
        }
    }
}




