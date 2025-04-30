using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class WindSystem : ParticleWeatherBase
{
    [HideInInspector]
    public Vector3 windDirection;
    [HideInInspector]
    public float baseSpeed = 25;

    public float speed = 1;

    private Vector3 lastWindDir;
    public event Action<Vector3> OnWindDirUpdated;

    private float interval = 1f;
    private double nextUpdateTime;

    public float trailLength = 0.5f;

    public Material mat;
    public Material matTrail;

    public float TrailSize = 0.5f;
    public Vector3 BoundSize = new Vector3(100, 20, 0);

    protected override void Start()
    {
        lastWindDir = windDirection;
        base.Start();
    }

    void Update()
    {
        
         DirForOtherWeatherWithDelay();
        
    }

    private void DirForOtherWeatherWithDelay()
    {
        double currentTime = Application.isPlaying ? Time.time : UnityEditor.EditorApplication.timeSinceStartup;

        if (currentTime >= nextUpdateTime)
        {
            nextUpdateTime = currentTime + interval;

            windDirection = transform.forward * speed;
            
            //Debug.Log(Time.time);
            //Debug.Log("forward: " + transform.forward);
            //Debug.Log("windDir: " + windDirection);
        }

        if (windDirection != lastWindDir)
        {
            lastWindDir = windDirection;
            OnWindDirUpdated?.Invoke(windDirection);
            //Debug.Log(11111 );
        }
    }

#if UNITY_EDITOR

    protected override void OnValidate()
    {
        base.OnValidate();
        OnWindDirUpdated?.Invoke(windDirection);
    }

    public override void ApplySettingInEditor()
    {
        if (overrideParticleSystem)
        {
            if (Application.isPlaying) return;
            if (par == null) return;

            var part = par.main;
            var em = par.emission;
            var trail = par.trails;
            var shape = par.shape;

            part.startSize = TrailSize;
            part.startSpeed = baseSpeed * speed;
            trail.lifetime = trailLength;
            shape.scale = BoundSize;

            var ren = par.GetComponent<ParticleSystemRenderer>();
            ren.material = mat;
            ren.trailMaterial = matTrail;
            
        }
    }

#endif
}
