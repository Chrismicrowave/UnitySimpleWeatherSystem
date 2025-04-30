using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(WeatherSystem))]

public class WeatherSystemCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        WeatherSystem weatherSystem = (WeatherSystem)target;

        if (GUILayout.Button("Create Rain GameObject"))
        {
            weatherSystem.CreateRain(); // Call the function on the MonoBehaviour
        }

        if (GUILayout.Button("Create Hail GameObject"))
        {
            weatherSystem.CreateHail(); // Call the function on the MonoBehaviour
        }

        if (GUILayout.Button("Create Snow GameObject"))
        {
            weatherSystem.CreateSnow(); // Call the function on the MonoBehaviour
        }

        if (GUILayout.Button("Create Wind GameObject"))
        {
            weatherSystem.CreateWind(); // Call the function on the MonoBehaviour
        }
    }
}
