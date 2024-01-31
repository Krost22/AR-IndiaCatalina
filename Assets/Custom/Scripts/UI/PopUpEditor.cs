
#region Editor
#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

[UnityEditor.CustomEditor(typeof(PopUp))]
public class PopUpEditor : Editor
{
    private PopUp currentTarget;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        currentTarget = (PopUp)target;

        GUILayout.Space(20);

        if(GUILayout.Button("Generar PopUps"))
        {
            Debug.LogWarning("a");
            EditorCoroutine _generacionPopUps = EditorCoroutineUtility.StartCoroutine(ClearAndGeneratePopUps(), this); 
            

        }
       
    }

    IEnumerator ClearAndGeneratePopUps()
    {
        foreach (var popUp in currentTarget.instanciasPopUp)
        {
            popUp.Destroy();
        }
        yield return new EditorWaitForSeconds(0.5f);
        currentTarget.instanciasPopUp.Clear();
        yield return new EditorWaitForSeconds(0.5f);
        currentTarget.GeneratePopUps();
    }

}
#endif
#endregion