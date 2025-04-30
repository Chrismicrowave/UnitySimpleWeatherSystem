using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEditor;



[Serializable]
public class WindSystemClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps
    { get { return ClipCaps.None; } }


    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {

        var clipBehaviour = ScriptPlayable<WindSystemClipBehaviour>.Create(graph);
        return clipBehaviour;
    }



}
