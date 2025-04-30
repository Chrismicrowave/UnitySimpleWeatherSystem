using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class WindSystemClipBehaviour : PlayableBehaviour
{

    private bool firstFrameHappened = false;

    [HideInInspector]
    public ParticleSystem par;

    private WindSystem weather;

    private bool keepPlaying;
    private bool clearOnStop;
    private bool usingTimeline;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        

        weather = playerData as WindSystem;
        keepPlaying = weather.playingIndefinitelyInGame;
        clearOnStop = weather.clearParticleOnStop;

        par = weather.GetComponent<ParticleSystem>();

        usingTimeline = weather.usingTimeline;
        if (!usingTimeline) return;

        if (info.weight > 0f)
        {

            if (!firstFrameHappened)
            {
                firstFrameHappened = true;

                par.Play();//play when cursor on clip

                if (!weather.overrideParticleSystem) return;//apply setting below only if overridding par sys

                var part = par.main;
                var em = par.emission;

                if (par == null) return;


               

            }


           
        }

    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        firstFrameHappened = false;

        if (!usingTimeline) return;

        if (par != null && par.isPlaying && !keepPlaying)
        {
            if (clearOnStop)
            { par.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); }
            else
            { par.Stop(true, ParticleSystemStopBehavior.StopEmitting); }
        }

        base.OnBehaviourPause(playable, info);
    }


}
