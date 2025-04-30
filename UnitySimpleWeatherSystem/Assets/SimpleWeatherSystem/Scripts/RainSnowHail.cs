using UnityEngine;

[ExecuteInEditMode]

public class RainSnowHail : ParticleWeatherBase
{
    
    public WeatherShape weatherBoundShape = WeatherShape.Rectangle;
    public Color dropletColor = Color.white;
    public float dropletSize = 0.05f;
    public float dropletLife = 3f;
    public int dropletEmissionAmount = 100;
    public int speed = 10;

    public int maxParticleAmount = 20000;
    public Vector3 BoundSize = new Vector3(100, 100, 1);
    public enum WeatherShape
    {
        Cone,
        Rectangle
    }

    public bool useWindSystemDirection = false;
    public Vector3 directionSpeed;
    public WindSystem windSys;

    public Material mat;


    protected override void OnEnable()
    {
        par = GetComponent<ParticleSystem>();

    }

    protected override void Start()
    {
        base.Start();
        if (windSys == null)
        {
            GetWindSys();
            if (windSys != null)
            {
                windSys.OnWindDirUpdated += HandleWindsysDirChanged;
            }
        }
    }

    private void GetWindSys()
    {
        if(windSys == null)
        {
            foreach (Transform child in transform.parent)
            {
                if(child.TryGetComponent<WindSystem>(out WindSystem wind))
                {
                    windSys = wind;
                    break;
                }
                
            }
        }
      

        if (windSys == null)
        {
            //Debug.Log("Please generate a Wind System in Weather System's inspector window");
            return;
        }

        windSys.OnWindDirUpdated += HandleWindsysDirChanged;
    }

    private void UpdateWindSysDirToLocal()
    {
        if (windSys == null) GetWindSys();

        if (windSys == null) { Debug.Log("Please generate a Wind System in Weather System's inspector window"); return; }
        if (par == null) { Debug.Log("Please add a particle system to this gameobject"); return; }

#if UNITY_EDITOR
        windSys.OnWindDirUpdated += HandleWindsysDirChanged; //need to resubscribe to event in editor mode
#endif

        var velocityOverLifetime = par.velocityOverLifetime;
        velocityOverLifetime.x = windSys.windDirection.x;
        velocityOverLifetime.y = windSys.windDirection.y;
        velocityOverLifetime.z = windSys.windDirection.z;

        //Debug.Log(2222);
    }

    private void HandleWindsysDirChanged(Vector3 dir)
    {
        if (useWindSystemDirection)
        { 
            UpdateWindSysDirToLocal();
        }
    }


    public override void ApplySettingInEditor()
    {
        if (overrideParticleSystem)
        {
            if (Application.isPlaying) return;
            if (par == null) return;

            var part = par.main;
            var em = par.emission;
            var shape = par.shape;

            part.startSize = dropletSize;
            part.startLifetime = dropletLife;
            part.startColor = dropletColor;
            part.startSpeed = speed;
            em.rateOverTime = dropletEmissionAmount;
            part.maxParticles = maxParticleAmount;
            shape.scale = BoundSize;

            var ren = par.GetComponent<ParticleSystemRenderer>();
            ren.material = mat;


            if (!useWindSystemDirection)
            {
                var velocityOverLifetime = par.velocityOverLifetime;
                velocityOverLifetime.x = directionSpeed.x;
                velocityOverLifetime.y = directionSpeed.y;
                velocityOverLifetime.z = directionSpeed.z;
            }
            else
            {

                UpdateWindSysDirToLocal();

            }

            switch (weatherBoundShape)
            {
                
                case WeatherShape.Cone:
                    shape.shapeType = ParticleSystemShapeType.Cone;
                    break;
                
                case WeatherShape.Rectangle:
                    shape.shapeType = ParticleSystemShapeType.Rectangle;
                    break;
            }

            //Debug.Log("setting applied");
        }
    }

 

}

