using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(PlayerController))]
public class PlayerController_Editor : Editor {

    bool folder = false;
    PlayerController controller;
    public override void OnInspectorGUI()
    {
        controller = (PlayerController)target;
        EditorGUILayout.LabelField("-- Player Controller --",EditorStyles.boldLabel);
        if(controller.variables == null)
        controller.variables = new PlayerVariables();

        controller.variables.acceleration = EditorGUILayout.FloatField(new GUIContent("Acceleration","Acceleration of Player, used for impulse controller"), controller.variables.acceleration);
        controller.variables.max_accel = EditorGUILayout.FloatField(new GUIContent("Max Acceleration", "Control acceleration of player"), controller.variables.max_accel);
        controller.variables.mass = EditorGUILayout.FloatField(new GUIContent("Player Mass","Mass of Player, used for calculation of physics, the rigidbody2D->mass is ignored, change this"), controller.variables.mass);
        controller.variables.angularSpeed = EditorGUILayout.FloatField(new GUIContent("Angular Speed","Change turn speed after change direction in game"), controller.variables.angularSpeed);
        controller.variables.jumpHeight = EditorGUILayout.FloatField(new GUIContent("Jump Height","Jump Force of Player"), controller.variables.jumpHeight);
        controller.variables.gravityScale = EditorGUILayout.FloatField(new GUIContent("Gravity","Gravity Player, the Unity gravity won't afect player"), controller.variables.gravityScale);
        controller.variables.footCheck = EditorGUILayout.FloatField(new GUIContent("Foot Checker","Change foot offset, this property used to check floor"), controller.variables.footCheck);
        folder = EditorGUILayout.Foldout(folder, "States");
        if (folder)
            DrawStates();
    }
    void DrawStates()
    {
        EditorGUILayout.HelpBox("Before Play, please press Save Button", MessageType.Warning);
        foreach (CState state in controller.states.states)
        {
            EditorGUILayout.BeginHorizontal();
            state.name = EditorGUILayout.TextField(state.name);
            state.asset =(TextAsset)EditorGUILayout.ObjectField(state.asset, typeof(TextAsset));
            if (Application.isPlaying)
                if (GUILayout.Button("^"))
                    controller.SetState(state.name);

            if (GUILayout.Button("x"))
                controller.states.states.Remove(state);
                
            EditorGUILayout.EndHorizontal();
        }
        if(GUILayout.Button("Add State"))
        {
            controller.states.states.Add(new CState());
            //Force Repaint
            Repaint();
        }
        if(GUILayout.Button("Create State"))
        {
            CreateState();
        }
        if (GUILayout.Button("Save"))
        {
            Save();
        }
    }
    void CreateState()
    {
        string path =EditorUtility.SaveFilePanel("Save State", "Assets/Scripts/Controllers/ControllerPreset", "state", "txt");
        if(path != null || path != string.Empty)
        {
            ControllerSerialization.Save(controller.variables, path);
            AssetDatabase.Refresh();
        }
    }
    void Save()
    {
        for (int i = 0; i < controller.states.states.Count; i++) {
            EditorUtility.DisplayProgressBar("Saving States", string.Format("Saving State: ({0},{1})", i + 1, controller.states.states.Count), i / controller.states.states.Count);
            controller.states.states[i].obj =(PlayerVariables)ControllerSerialization.Load(controller.states.states[i].asset.bytes);
           }
        EditorUtility.ClearProgressBar();
    }
}
