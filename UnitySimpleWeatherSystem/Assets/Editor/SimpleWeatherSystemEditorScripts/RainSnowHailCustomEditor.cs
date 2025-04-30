using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RainSnowHail))]
public class RainSnowHailCustomEditor : Editor
{
    SerializedProperty playingIndefinitelyInGame;
    SerializedProperty overrideParticleSystem;
    SerializedProperty weatherBoundShape;
    SerializedProperty dropletSize;
    SerializedProperty dropletColor;
    SerializedProperty dropletLife;
    SerializedProperty dropletEmissionAmount;
    SerializedProperty speed;
    SerializedProperty useWindSystemDirection;
    SerializedProperty directionSpeed;
    SerializedProperty clearParticleOnStop;
    SerializedProperty windSys;
    SerializedProperty usingTimeline;
    SerializedProperty playParticleOnStart;
    SerializedProperty maxParticleAmount;
    SerializedProperty mat;
    SerializedProperty BoundSize;

    private void OnEnable()
    {
        playingIndefinitelyInGame = serializedObject.FindProperty("playingIndefinitelyInGame");
        overrideParticleSystem = serializedObject.FindProperty("overrideParticleSystem");
        weatherBoundShape = serializedObject.FindProperty("weatherBoundShape");
        dropletSize = serializedObject.FindProperty("dropletSize");
        dropletColor = serializedObject.FindProperty("dropletColor");
        dropletLife = serializedObject.FindProperty("dropletLife");
        dropletEmissionAmount = serializedObject.FindProperty("dropletEmissionAmount");
        speed = serializedObject.FindProperty("speed");
        useWindSystemDirection = serializedObject.FindProperty("useWindSystemDirection");
        directionSpeed = serializedObject.FindProperty("directionSpeed");
        clearParticleOnStop = serializedObject.FindProperty("clearParticleOnStop");
        windSys = serializedObject.FindProperty("windSys");
        usingTimeline = serializedObject.FindProperty("usingTimeline");
        playParticleOnStart = serializedObject.FindProperty("playParticleOnStart");
        maxParticleAmount = serializedObject.FindProperty("maxParticleAmount");
        mat = serializedObject.FindProperty("mat");
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
            EditorGUILayout.PropertyField(weatherBoundShape, new GUIContent("Weather Bound Shape"));
            EditorGUILayout.PropertyField(dropletSize, new GUIContent("Droplet Size"));
            EditorGUILayout.PropertyField(dropletColor, new GUIContent("Droplet Color"));
            EditorGUILayout.PropertyField(dropletLife, new GUIContent("Droplet Life"));
            EditorGUILayout.PropertyField(dropletEmissionAmount, new GUIContent("Droplet Emission Amount"));
            EditorGUILayout.PropertyField(speed, new GUIContent("Speed"));
            EditorGUILayout.PropertyField(maxParticleAmount, new GUIContent("Max Particle"));
            EditorGUILayout.PropertyField(BoundSize, new GUIContent("Bound Size"));
            EditorGUILayout.PropertyField(mat, new GUIContent("Material"));

            EditorGUILayout.PropertyField(useWindSystemDirection, new GUIContent("Use Wind System Direction"));
            
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(!useWindSystemDirection.boolValue);
            {
                EditorGUILayout.PropertyField(windSys, new GUIContent("Wind System"));
            }
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(useWindSystemDirection.boolValue);
            { 
                EditorGUILayout.PropertyField(directionSpeed, new GUIContent("Local Direction Speed"));
            }
            EditorGUI.EndDisabledGroup();
            EditorGUI.indentLevel--;

        }
        EditorGUI.EndDisabledGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
