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
    

    static public void Save(string Name)
    {
        AssetDatabase.CreateFolder("Assets/Edouard/Tools/DayNightTool/SavedSettings", Name);
        string Path = "Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name + "/" + Name +".lighting";
        
        var activeScene = EditorSceneManager.GetActiveScene();

        if(Lightmapping.TryGetLightingSettings(out LightingSettings settings))
        {
            Current_SourceLightingSettings = Lightmapping.GetLightingSettingsForScene(activeScene); 
            Saved_SourceLightingSettings = Instantiate(Current_SourceLightingSettings);
            AssetDatabase.CreateAsset(Saved_SourceLightingSettings,Path);
        }
        else
        {
            Debug.LogErrorFormat("No Current Lightning Settings to save!");
        }
    }
}

///Lightmapping.SetLightingSettingsForScene(activeScene, Saved_SourceLightingSettings); 


