using UnityEngine;

[ExecuteInEditMode]
//[ExecuteAlways]

public abstract class ParticleWeatherBase : MonoBehaviour
{
    
    [HideInInspector]
    public ParticleSystem par;

    [HideInInspector]
    public bool startPlayingInEditor = false;

    [HideInInspector]
    public bool isManuallySelectedInEditor = false;

    public bool usingTimeline = true;
    public bool playParticleOnStart = false;

    public bool playingIndefinitelyInGame = false;
    public bool overrideParticleSystem = true;
    public bool clearParticleOnStop = true;

    protected virtual void OnEnable()
    {
        par = GetComponent<ParticleSystem>();
    }

    protected virtual void Start()
    {
        if(usingTimeline) { par.Stop(); playParticleOnStart = false; }
        if(playParticleOnStart) par.Play();
    }



#if UNITY_EDITOR
    protected void OnDrawGizmosSelected()
    {
        if (Application.isPlaying) return;

        if (!isManuallySelectedInEditor)
        {
            isManuallySelectedInEditor = true;
            //ApplySettingInEditor();    
            RestartParInEditor();
            //Debug.Log(gameObject.name + " started in RSH onDrawGizmosSelected");
        }
    }

    public abstract void ApplySettingInEditor();

    protected void OnDrawGizmos()
    {
        if (Application.isPlaying) return;

        // Deselect detection
        if (!UnityEditor.Selection.Contains(gameObject))
        {
            if (isManuallySelectedInEditor)
            {
                PauseParInEditor();
                //Debug.Log(gameObject.name + " stoped in RSH onDrawGizmosSelected");
            }

            isManuallySelectedInEditor = false;
        }
    }

  

    public void RestartParInEditor()
    {
        if (Application.isPlaying) return;

        if (par == null) return;
        par.Clear();
        par.Play();
        //Debug.Log(gameObject.name + " played in RSH RestartPar");
    }

    public void PauseParInEditor()
    {
        if (Application.isPlaying) return;

        if (par == null) return;
        par.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }


    protected virtual void OnValidate()
    {
        if (Application.isPlaying) return;

        if (par != null)
        {
            ApplySettingInEditor();

            if (startPlayingInEditor)
            {
                RestartParInEditor();
                //Debug.Log(gameObject.name + " played in RSH OnValidate");
            }
        }

        if (usingTimeline) { playParticleOnStart = false; }
    }

#endif

}
