using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampMenu : MonoBehaviour
{
    public GameObject menu;
    public Slider slider;
    public Light lampLight;

    bool power = false;
    public float intensity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        lampLight.enabled = power;
        slider.value = intensity;
    }

    // Update is called once per frame
    void Update()
    {
        lampLight.enabled = power;
        lampLight.intensity = slider.value;
    }

    public void powerPressed()
    {
        power = !power;
    }

    public void exitPressed()
    {
        menu.SetActive(false);
    }
}
