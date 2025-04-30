//#if UNITY_EDITOR

//using UnityEditor;
//using UnityEngine;

//[InitializeOnLoad]
//public static class WindEditorUpdate
//{
//    static WindEditorUpdate()
//    {
//        EditorApplication.update += UpdateInEditor;
//    }


//    private static double lastUpdateTime;
//    private const double updateInterval = 1 / 30f; // ~30 FPS, enough for editor preview

//    private static void UpdateInEditor()
//    {
//        if (Application.isPlaying) return;

//        double currentTime = EditorApplication.timeSinceStartup;
//        if (currentTime - lastUpdateTime < updateInterval) return;

//        lastUpdateTime = currentTime;

//        var allInstances = GameObject.FindObjectsByType<WindSystem>(FindObjectsSortMode.None);
//        foreach (var weather in allInstances)
//        {
//            if (weather.par == null) continue;

//            if (weather.isManuallySelectedInEditor)
//            {
//                // Let manual selection take full control
//                continue;
//            }

//            if (weather.startPlayingInEditor)
//            {
//                weather.par.Play();
//                weather.par.Simulate(Time.deltaTime, true, false);
//                //Debug.Log(weather.name + " played in RSHeditorUpdate");
//            }
//            else
//            {
//                weather.par.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
//                //Debug.Log( weather.name + " stoped in RSHeditorUpdate");
//                //** constantly running in editor mode**
//            }
//        }
//    }

//}

//#endif