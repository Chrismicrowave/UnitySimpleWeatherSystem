using UnityEngine;
using UnityEngine.SceneManagement;

public class WeatherSystem : MonoBehaviour
{
    public GameObject Rain;
    public GameObject Hail;
    public GameObject Snow;
    public GameObject Wind;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    }

    public void CreateRain()
    {
        createWeather(Rain);
    }

    public void CreateHail()
    {
        createWeather(Hail);
    }

    public void CreateSnow()
    {
        createWeather(Snow);
    }

    public void CreateWind()
    {
        createWeather(Wind);
    }

    public void createWeather(GameObject weatherPrefab)
    {
        int count = 0;

        GameObject weather = Instantiate(weatherPrefab);
        weather.transform.parent = transform;

        // Use the base name directly from the prefab
        string baseName = weatherPrefab.name;

        // Count existing siblings with the same base name
        foreach (Transform sibling in transform)
        {
            if (sibling.name.StartsWith(baseName))
            {
                count++;
            }
        }

        // Set new name
        weather.name = baseName + " - " + count;
    }
}
