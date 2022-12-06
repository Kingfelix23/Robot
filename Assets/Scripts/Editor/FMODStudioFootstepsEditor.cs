

using UnityEditor;            

[CustomEditor(typeof(FMODStudioMaterialSetter))]                                                              
public class FMODStudioFootstepsEditor : Editor                                                              
{
    public override void OnInspectorGUI()                                                                    
    {
        var MS = target as FMODStudioMaterialSetter;                                                         
        var FPF = FindObjectOfType<FootstepScriptNEW>();                                  

        MS.MaterialValue = EditorGUILayout.Popup("Set Material As", MS.MaterialValue, FPF.MaterialTypes);   
    }
}


[CustomEditor(typeof(FootstepScriptNEW))] 
public class FMODStudioFootstepsEditorTwo : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();                                                                                                     

        var FPF = target as FootstepScriptNEW;                                                                         

        FPF.DefulatMaterialValue = EditorGUILayout.Popup("Set Default Material As", FPF.DefulatMaterialValue, FPF.MaterialTypes);  
    }
}
