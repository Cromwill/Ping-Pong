using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayersClampArea))]
public class PlayersClampAreaEditor : Editor
{
    protected virtual void OnSceneGUI()
    {
        var v = (PlayersClampArea)target;

        EditorGUI.BeginChangeCheck();

        v.RectUpperPoint = Handles.PositionHandle(v.transform.position + (Vector3)v.RectUpperPoint, Quaternion.identity) - v.transform.position;
        v.RectDownerPoint = Handles.PositionHandle(v.transform.position + (Vector3)v.RectDownerPoint, Quaternion.identity) - v.transform.position;

        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(v, "Change points");
        }
    }

}
