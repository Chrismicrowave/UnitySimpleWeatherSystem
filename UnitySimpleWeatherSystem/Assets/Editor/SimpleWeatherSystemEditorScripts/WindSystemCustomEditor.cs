using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WindSystem))]
public class WindSystemCustomEditor : Editor
{
    SerializedProperty playingIndefinitelyInGame;
    SerializedProperty overrideParticleSystem;
    SerializedProperty clearParticleOnStop;
    SerializedProperty usingTimeline;
    SerializedProperty playParticleOnStart;
    SerializedProperty trailLength;
    SerializedProperty mat;
    SerializedProperty matTrail;
    SerializedProperty speed;
    SerializedProperty TrailSize;
    SerializedProperty BoundSize;

    private void OnEnable()
    {
        playingIndefinitelyInGame = serializedObject.FindProperty("playingIndefinitelyInGame");
        overrideParticleSystem = serializedObject.FindProperty("overrideParticleSystem");
        
       
        clearParticleOnStop = serializedObject.FindProperty("clearParticleOnStop");
        usingTimeline = serializedObject.FindProperty("usingTimeline");
        playParticleOnStart = serializedObject.FindProperty("playParticleOnStart");


        speed = serializedObject.FindProperty("speed");
        trailLength = serializedObject.FindProperty("trailLength");

        mat = serializedObject.FindProperty("mat");
        matTrail = serializedObject.FindProperty("matTrail");

        TrailSize = serializedObject.FindProperty("TrailSize");
        BoundSize = serializedObject.FindProperty("BoundSize");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("--- General Setting ---");

        EditorGUILayout.PropertyField(usingTimeline, new GUIContent("Using Timeline"));

        EditorGUI.BeginDisabledGroup(usingTimeline.boolValue);
        {
            EditorGUILayout.PropertyField(playParticleOnStart, new GUIContent("Play Particle On Start"));
        }
        EditorGUI.EndDisabledGroup();


        EditorGUI.BeginDisabledGroup(!usingTimeline.boolValue);
        {
            EditorGUILayout.LabelField("--- Weather Clip Setting ---");
        
            EditorGUILayout.PropertyField(playingIndefinitelyInGame, new GUIContent("Play Indefinitely In Game"));
            EditorGUILayout.PropertyField(clearParticleOnStop, new GUIContent("Clear Particle On Stop"));
        }
        EditorGUI.EndDisabledGroup();

        EditorGUILayout.LabelField("--- Particle System Setting ---");

        EditorGUILayout.PropertyField(overrideParticleSystem, new GUIContent("Override Particle System"));

        EditorGUI.BeginDisabledGroup(!overrideParticleSystem.boolValue);
        {
            
            EditorGUILayout.PropertyField(speed, new GUIContent("Speed"));
            EditorGUILayout.PropertyField(TrailSize, new GUIContent("Trail Size"));
            EditorGUILayout.PropertyField(trailLength, new GUIContent("Trail Length"));
            EditorGUILayout.PropertyField(BoundSize, new GUIContent("Bound Size"));
            EditorGUILayout.PropertyField(mat, new GUIContent("Material"));
            EditorGUILayout.PropertyField(matTrail, new GUIContent("Trail Material"));
        }
        EditorGUI.EndDisabledGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
