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

public class WeatherController : MonoBehaviour
{
    private const string API_KEY = "6053b37da94470bbbd0dc501ace7312e";
    private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes

    public string cityId;
    public TextMeshProUGUI weatherText;

    public WeatherInfo info;

    double latitude = 32.777963, longitude = -96.79622;

    private float apiCheckCountdown = API_CHECK_MAXTIME;

    // Start is called before the first frame update
    void Start()
    {
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
        weatherText.text = info.weather[0].main;

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
