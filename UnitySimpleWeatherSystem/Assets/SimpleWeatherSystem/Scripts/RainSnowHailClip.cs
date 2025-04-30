using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEditor;



[Serializable]
public class RainSnowHailClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps
    { get { return ClipCaps.None; } }


    //----V4----

    //private ParticleClipBehaviour clipSetting = new ParticleClipBehaviour();

    //public ParticleClipBehaviour GetClipSetting()
    //{
    //    return clipSetting;
    //}

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {

        var clipBehaviour = ScriptPlayable<RainSnowHailClipBehaviour>.Create(graph);
        return clipBehaviour;
    }



}

////----V3----
//public ExposedReference<RainSnowHail> rainSnowHailRef;

//public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
//{
//    var playable = ScriptPlayable<ParticleClipBehaviour>.Create(graph);
//    var behaviour = playable.GetBehaviour();

//    // Assign reference into the behaviour
//    behaviour.rainSnowHailRef = rainSnowHailRef;

//    // Try to resolve from the director if not already set
//    if (rainSnowHailRef.exposedName == default)
//    {
//        var director = owner.GetComponent<PlayableDirector>();
//        if (director != null)
//        {
//            foreach (var output in director.playableAsset.outputs)
//            {
//                if (output.outputTargetType == typeof(RainSnowHail))
//                {
//                    var bound = director.GetGenericBinding(output.sourceObject) as RainSnowHail;
//                    if (bound != null)
//                    {
//                        // Set reference both to asset and behaviour
//                        rainSnowHailRef.defaultValue = bound;
//                        behaviour.rainSnowHailRef = rainSnowHailRef;
//                        break;
//                    }
//                }
//            }
//        }
//    }

//    return playable;
//}



////----V2----
//public ExposedReference<RainSnowHail> rainSnowHailRef;

//public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
//{
//    var playable = ScriptPlayable<ParticleClipBehaviour>.Create(graph);

//    var behaviour = playable.GetBehaviour();
//    var weather = rainSnowHailRef.Resolve(graph.GetResolver());

//    if (weather != null)
//    {
//        behaviour.color = weather.color;
//        behaviour.life = weather.life;
//        behaviour.amount = weather.amount;
//    }

//    return playable;
//}


////----V1----

//private ParticleClipBehaviour clipSetting = new ParticleClipBehaviour();


//public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
//{

//    return ScriptPlayable<ParticleClipBehaviour>.Create(graph, clipSetting);

//}


