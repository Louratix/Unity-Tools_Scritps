using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
using UnityEditor;
using System;
using System.IO;
using UnityEngine.Rendering;


[Overlay(typeof(SceneView),id : ID_OVERLAY, displayName : "DayNightTool")]

public class DayNightSkyboxOverlay : Overlay
{
    private const string ID_OVERLAY = "DayNightTool Overlay";

    public string Name;
        public override VisualElement CreatePanelContent()
    {
        var root = new VisualElement();
        var titleLabel = new Label(text: "------------------");
        var textField = new TextField();
        textField.value = "Name:";
        root.Add(new Button(() => Refresh()) { name="RefreshButton" ,text = "Refresh" });
        root.Add(new Button(() => onClick(textField.value, root)) { name="SaveNEW" ,text = "SaveNew" });
        root.Add(textField);
        root.Add(titleLabel);

        string[] SavedSettings = Directory.GetFiles("Assets/Edouard/Tools/DayNightTool/SavedSettings/");
        foreach(string Folders in SavedSettings)
        {
            Name = Path.GetFileNameWithoutExtension(Folders);
            Debug.Log(Name);
            onClicked(Name, root);
        }

        return root;
    }

    private void Refresh()
    {
        displayed = false;
        displayed = true;
    }

    void onClick(string Name, VisualElement root)
    {
        SavingSettings.Save(Name);
        ///SavedData.Save(Name);
        onClicked(Name, root);

    }

    private void onClicked(string Name, VisualElement root)
    {
        var row = new VisualElement();
        row.style.flexDirection = FlexDirection.Row;
        Button button = new Button(() => SetSetting(Name)){ name=Name, text = Name };
        Debug.Log(Name);
        row.Add(button);
        row.Add(new Button(() => Update(Name)) { name= Name +"S" ,text = "Save", visible = true});
        row.Add(new Button(() => Delete(Name)) { name= Name +"D" ,text = "X", visible = true});
        root.Add(row);
    }

    private void SetSetting(string Name)
    {
        //row.Query().Where(elem => elem.name == Name + "S").ForEach(elem => elem.visible = false);
        //row.Query().Where(elem => elem.name == Name + "D").ForEach(elem => elem.visible = false);

        SetSettings.Apply(Name);

        //List<VisualElement> SaveButton = row.Query(Name +"S").ToList();
        //List<VisualElement> DeleteButton = row.Query(Name +"D").ToList();
        //SaveButton[0].visible = true;
        //DeleteButton[0].visible = true;
    }

    private void Delete(string Name)
    {
        AssetDatabase.DeleteAsset("Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name + ".meta"); 
        FileUtil.DeleteFileOrDirectory("Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name);
        Debug.Log("Assets/Edouard/Tools/DayNightTool/SavedSettings/" + Name);
        displayed = false;
        displayed = true;
    }

    private void Update(string Name)
    {
        UpdateSettings.UpdateSetting(Name);
        SetSettings.Apply(Name);
    }


}
