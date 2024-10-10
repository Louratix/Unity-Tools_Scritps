using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
using UnityEditor;


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
        root.Add(new Button(() => SavingSettings.Save(textField.value)) { text = "SaveCurrent" });
        root.Add(textField);
        root.Add(titleLabel);

        return root;
    }
}
