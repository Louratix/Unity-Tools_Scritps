using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UIElements;
using UnityEditor.Overlays;


public class SetSettings : MonoBehaviour
{
    static public void Apply(string Name, VisualElement row)
    {
        var activeScene = EditorSceneManager.GetActiveScene();
        LightingSettings Saved_SourceLightingSettings = (LightingSettings)AssetDatabase.LoadAssetAtPath("Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name + "/" + Name +".lighting", typeof(LightingSettings));
        Lightmapping.SetLightingSettingsForScene(activeScene, Saved_SourceLightingSettings);

        //string loadPlayerData = File.ReadAllText(SavedData.savepath + Name + "/" + Name + ".json");
        //EnvironmentData LoadedData = JsonUtility.FromJson<EnvironmentData>(loadPlayerData);
        //RenderSettings.skybox = LoadedData.skyboxMaterial;
        Material SkyboxMaterial = (Material)AssetDatabase.LoadAssetAtPath("Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name + "/" + Name +".mat", typeof(Material));
        RenderSettings.skybox = SkyboxMaterial;
    
    }
}
