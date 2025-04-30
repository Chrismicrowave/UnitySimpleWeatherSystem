#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;
using System.Linq;

//Script for particle system to be played when users click the clip in timeline
[InitializeOnLoad]
public static class TimelineClipSelectionHandler
{
    static TimelineClip lastSelectedClip = null;

    static TimelineClipSelectionHandler()
    {
        EditorApplication.update += CheckClipSelection;
    }

    private static void CheckClipSelection()
    {
        if (Application.isPlaying) return;

        var director = TimelineEditor.inspectedDirector;
        var timeline = TimelineEditor.inspectedAsset;

        if (director == null || timeline == null) return;

        var selectedClip = TimelineEditor.selectedClips.FirstOrDefault();

        if (selectedClip == lastSelectedClip)
            return;

        lastSelectedClip = selectedClip;

        foreach (var track in timeline.GetOutputTracks())
        {
            var binding = director.GetGenericBinding(track);
            var weatherEffect = binding as ParticleWeatherBase;
            if (weatherEffect == null) continue;

            bool isClipOnTrackSelected = selectedClip != null && selectedClip.GetParentTrack() == track;

            weatherEffect.startPlayingInEditor = isClipOnTrackSelected;

            if (isClipOnTrackSelected)
            {
                weatherEffect.RestartParInEditor();
            }
            else
            {
                weatherEffect.PauseParInEditor();
            }

            if (weatherEffect.overrideParticleSystem)
            {
                EditorUtility.SetDirty(weatherEffect);
            }
            else if (weatherEffect.par != null)
            {
                EditorUtility.SetDirty(weatherEffect.par);
            }
        }
    }
}

#endif


