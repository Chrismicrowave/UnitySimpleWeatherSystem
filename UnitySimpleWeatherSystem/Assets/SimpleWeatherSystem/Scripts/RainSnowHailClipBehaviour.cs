using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class RainSnowHailClipBehaviour : PlayableBehaviour
{
    //public Color color;
    //public float life;
    //public int amount;

    private bool firstFrameHappened = false;

    [HideInInspector]
    public ParticleSystem par;

    private RainSnowHail weather;

    private bool keepPlaying;

    private bool clearOnStop;

    private bool usingTimeline;

    //public ExposedReference<RainSnowHail> rainSnowHailRef;

    //public override void OnPlayableCreate(Playable playable)
    //{
    //    base.OnPlayableCreate(playable);
    //}

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        //weather = rainSnowHailRef.Resolve(playable.GetGraph().GetResolver());

        //par = playerData as ParticleSystem;

        weather = playerData as RainSnowHail;
        keepPlaying = weather.playingIndefinitelyInGame;
        clearOnStop = weather.clearParticleOnStop;

        usingTimeline = weather.usingTimeline;
        if (!usingTimeline) return;

        par = weather.GetComponent<ParticleSystem>();

        if(!weather.usingTimeline) return;

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

                //part.startLifetime = life;
                //part.startColor = color;
                //em.rateOverTime = amount;

                part.startLifetime = weather.dropletLife;
                part.startColor = weather.dropletColor;
                em.rateOverTime = weather.dropletEmissionAmount;

                //Debug.Log(playerData.ToString());



            }


        }

    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        firstFrameHappened = false;

        //if (par == null) return;
        //var part = par.main;
        //var em = par.emission;
        //part.startLifetime = 0;
        //em.rateOverTime = 0;

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
