#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Timeline;
using System.Linq;

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

//bakcup

//#if UNITY_EDITOR

//using UnityEditor;
//using UnityEditor.Timeline;
//using UnityEngine;
//using UnityEngine.Timeline;
//using System.Linq;

//[InitializeOnLoad]
//public static class ParticleClipSelectionHandler
//{
//    static TimelineClip lastSelectedClip = null;

//    static ParticleClipSelectionHandler()
//    {
//        EditorApplication.update += CheckClipSelection;
//    }

//    private static void CheckClipSelection()
//    {
//        if (Application.isPlaying) return;

//        var director = TimelineEditor.inspectedDirector;
//        var timeline = TimelineEditor.inspectedAsset;

//        if (director == null || timeline == null) return;

//        // Get currently selected TimelineClip
//        var selectedClips = TimelineEditor.selectedClips;
//        var selectedClip = selectedClips.FirstOrDefault();

//        if (selectedClip == lastSelectedClip)
//            return; // Nothing changed

//        lastSelectedClip = selectedClip;

//        foreach (var track in timeline.GetOutputTracks())
//        {
//            var binding = director.GetGenericBinding(track);
//            var rainSnowHail = binding as RainSnowHail;
//            if (rainSnowHail == null) continue;

//            bool isClipOnTrackSelected = selectedClip != null && selectedClip.GetParentTrack() == track;

//            if (isClipOnTrackSelected)
//            {
//                rainSnowHail.startPlayingInEditor = true;
//                //rainSnowHail.ApplySettingInEditor();
//                rainSnowHail.RestartParInEditor();
//                //Debug.Log(rainSnowHail.name + " played in PClipSelectionHandler");
//            }
//            else
//            {
//                rainSnowHail.startPlayingInEditor = false;
//                rainSnowHail.PauseParInEditor();
//                //Debug.Log(rainSnowHail.name + " stopped in PClipSelectionHandler");
//            }

//            if (rainSnowHail.overrideParticleSystem)
//            {
//                EditorUtility.SetDirty(rainSnowHail);
//            }
//            else
//            {
//                var par = rainSnowHail.GetComponent<ParticleSystem>();
//                EditorUtility.SetDirty(par);

//                //SerializedObject so = new SerializedObject(par);
//                //so.ApplyModifiedPropertiesWithoutUndo();
//            }

//            //AssetDatabase.SaveAssets();
//        }
//    }
//}

//#endif
