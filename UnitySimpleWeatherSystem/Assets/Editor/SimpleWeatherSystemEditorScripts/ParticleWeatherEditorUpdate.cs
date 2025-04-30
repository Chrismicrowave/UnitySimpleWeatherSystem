#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

//Script for particle system to be played when user select the gameobject of the ParticleWeatherBase
[InitializeOnLoad]
public static class WeatherEffectEditorUpdate
{
    static WeatherEffectEditorUpdate()
    {
        EditorApplication.update += UpdateInEditor;
    }

    private static double lastUpdateTime;
    private const double updateInterval = 1 / 30f; // ~30 FPS

    private static void UpdateInEditor()
    {
        if (Application.isPlaying) return;

        double currentTime = EditorApplication.timeSinceStartup;
        if (currentTime - lastUpdateTime < updateInterval) return;

        lastUpdateTime = currentTime;

        var allEffects = GameObject.FindObjectsByType<ParticleWeatherBase>(FindObjectsSortMode.None);
        foreach (var effect in allEffects)
        {
            if (effect.par == null) continue;

            if (effect.isManuallySelectedInEditor)
                continue;

            if (effect.startPlayingInEditor)
            {
                effect.par.Play();
                effect.par.Simulate(Time.deltaTime, true, false);
            }
            else
            {
                effect.par.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }
}

#endif
