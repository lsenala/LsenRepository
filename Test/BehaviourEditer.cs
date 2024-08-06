using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(RevolverMenu))]
public class BehaviourEditer : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RevolverMenu  revolverMenu  = (RevolverMenu)target;
        GUIContent visualize = new GUIContent("Visualize Arrangement", "Press this to preview what the radial menu will look like ingame.");
        GUIContent reset = new GUIContent("Reset Arrangement", "Press this to reset all elements to a 0 rotation for easy editing.");
        if (!Application.isPlaying) {
            if (GUILayout.Button(visualize)) {
                arrangeElementsInEditor(revolverMenu , false);
            }
            if (GUILayout.Button(reset)) {
                arrangeElementsInEditor(revolverMenu , true);
            }
        }
    }
    public void arrangeElementsInEditor(RevolverMenu  revolverMenu , bool reset)
    {
        if (reset) {
            for (int i = 0; i < revolverMenu .elements.Count; i++) {
                if (revolverMenu.elements[i] == null) {
                    Debug.LogError("Radial Menu: element " + i.ToString() + " in the radial menu " + revolverMenu .gameObject.name + " is null!");
                    continue;
                }
                RectTransform elemRt = revolverMenu.elements[i].GetComponent<RectTransform>();
                elemRt.rotation = Quaternion.Euler(0, 0, 0);
            }
            return;
        }
        for (int i = 0; i < revolverMenu .elements.Count; i++) {
            if (revolverMenu .elements[i] == null) {
                Debug.LogError("Radial Menu: element " + i.ToString() + " in the radial menu " + revolverMenu .gameObject.name + " is null!");
                continue;
            }
            RectTransform elemRt = revolverMenu .elements[i].GetComponent<RectTransform>();
            elemRt.rotation = Quaternion.Euler(0, 0, -((360f / (float)revolverMenu .elements.Count) * i) - revolverMenu .globalOffset);
        }
    }
}
