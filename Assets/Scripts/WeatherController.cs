using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
using Assets;
using System.Threading.Tasks;
using UnityEngine.Android;
using TMPro;

public class WeatherObject
{
    public Color color;
    public GameObject weatherObject;

    public WeatherObject(Color color, GameObject weatherObject)
    {
        this.color = color;
        this.weatherObject = weatherObject;
    }
}

public class WeatherController : MonoBehaviour
{
    private const string API_KEY = "6053b37da94470bbbd0dc501ace7312e";
    private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes

    public string cityId;
    public TextMeshProUGUI weatherText;
    public GameObject thunderstorm, drizzle, rain, snow, clear, clouds;

    public WeatherInfo info;

    double latitude = 32.777963, longitude = -96.79622;

    public Dictionary<string, WeatherObject> hash = new Dictionary<string, WeatherObject>();

    bool weatherDisplay = false;

    private float apiCheckCountdown = API_CHECK_MAXTIME;


    // Start is called before the first frame update
    void Start()
    {
        hash.Add("Thunderstorm", new WeatherObject(Color.yellow, thunderstorm));
        hash.Add("Drizzle", new WeatherObject(Color.green, drizzle));
        hash.Add("Rain", new WeatherObject(Color.blue, rain));
        hash.Add("Snow", new WeatherObject(Color.white, snow));
        hash.Add("Clear", new WeatherObject(Color.cyan, clear));
        hash.Add("Clouds", new WeatherObject(new Color(0.75f, 0.75f, 0.75f), clouds));

        info = GetWeather();
    }

    // Update is called once per frame
    void Update()
    {
        apiCheckCountdown -= Time.deltaTime;
        if (apiCheckCountdown <= 0)
        {
            info = GetWeather();
            apiCheckCountdown = API_CHECK_MAXTIME;
        }

        if (OVRInput.GetUp(OVRInput.Button.Two) || Input.GetKeyUp(KeyCode.W))
        {
            weatherDisplay = !weatherDisplay;
        }

        foreach (var weather in hash)
        {
            weather.Value.weatherObject.SetActive(false);
        }

        if (weatherDisplay)
        {
            if (!hash.TryGetValue(info.weather[0].main, out WeatherObject weatherObject))
            {
                weatherObject = new WeatherObject(Color.red, clear);
            }

            weatherObject.weatherObject.SetActive(true);
        }
    }

    private WeatherInfo GetWeather()
    {
        // GetUserLocation();
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(
            String.Format("https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}", latitude, longitude, API_KEY)
            );
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);

        Debug.Log(info.ToString());
        string weather = info.weather[0].main;
        weatherText.text = weather;
        if (!hash.TryGetValue(weather, out WeatherObject weatherObject))
        {
            weatherObject = new WeatherObject(Color.red, clear);
        }

        weatherText.color = weatherObject.color;

        return info;
    }

    public void GetUserLocation()
    {
        if (!Input.location.isEnabledByUser)
        {
            weatherText.text = "No Location Permission";
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            weatherText.text = "Location Permission Granted";
            StartCoroutine(GetLatLonUsingGPS());
        }
    }

    IEnumerator GetLatLonUsingGPS()
    {
        Input.location.Start();
        int maxWait = 5;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        weatherText.text = "waiting before getting lat and lon";

        // Access granted and location value could be retrieve
        longitude = Input.location.lastData.longitude;
        latitude = Input.location.lastData.latitude;

        Input.location.Stop();
        StopCoroutine("Start");
    }
}
