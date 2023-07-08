using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Text;

[Serializable]
public class Weather
{
    public int id;
    public string main;
}

[Serializable]
public class WeatherInfo
{
    public int id;
    public string name;
    public List<Weather> weather;

    public override string ToString()
    {
        return id + " " + name + " " + weather.ToString();
    }
}