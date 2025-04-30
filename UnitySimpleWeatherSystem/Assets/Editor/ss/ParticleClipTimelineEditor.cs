

////----- decided to only let user to control parameter in gameobject NOT in timeline!! ------

//using UnityEditor;
//using UnityEditor.Timeline;
//using UnityEngine;
//using UnityEngine.Timeline;

//[CustomTimelineEditor(typeof(ParticleClip))]
//public class ParticleClipTimelineEditor : ClipEditor
//{

//    public override void OnCreate(TimelineClip clip, TrackAsset track, TimelineClip clonedFrom)
//    {
//        base.OnCreate(clip, track, clonedFrom);

//        ParticleClip particleClip = clip.asset as ParticleClip;
//        if (particleClip == null) return;

//        TimelineAsset timeline = TimelineEditor.inspectedAsset;
//        if (timeline == null) return;


//        // Get the object bound to the track
//        var director = TimelineEditor.inspectedDirector;
//        if (director == null) return;

//        var binding = director.GetGenericBinding(track);

//        var rainSnowHail = binding as RainSnowHail;
//        if (rainSnowHail == null) return;

//        // Set the clipSetting values from RainSnowHail
//        var setting = particleClip.GetClipSetting();
//        if (setting == null) return;

//        setting.life = rainSnowHail.life;
//        setting.amount = rainSnowHail.amount;
//        setting.color = rainSnowHail.color;

//        EditorUtility.SetDirty(particleClip);  // Mark asset dirty for saving
//    }
//}
