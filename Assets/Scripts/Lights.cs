using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public Light[] lights;
    public bool on;
    public Transform lightSwitch;

    // Start is called before the first frame update
    void Start()
    {
        on = lights[0].enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightsOff()
    {
        for (int x = 0; x < lights.Length; x++)
        {
            lights[x].enabled = false;
        }

        on = false;

        lightSwitch.transform.eulerAngles = new Vector3(
            lightSwitch.transform.eulerAngles.x,
            lightSwitch.transform.eulerAngles.y,
            180
        );
    }

    public void LightsOn()
    {
        for (int x = 0; x < lights.Length; x++)
        {
            lights[x].enabled = true;
        }

        on = true;

        lightSwitch.transform.eulerAngles = new Vector3(
            lightSwitch.transform.eulerAngles.x,
            lightSwitch.transform.eulerAngles.y,
            0
        );
    }
}
