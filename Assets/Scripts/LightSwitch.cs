using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwitch : MonoBehaviour
{
    public HoverBehaviour hoverBehaviour;
    public Lights lights;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hoverBehaviour.hovering && OVRInput.GetUp(OVRInput.Button.One))
        {
            if (lights.on)
            {
                lights.LightsOff();
                
            } else
            {
                lights.LightsOn();
            }
        }
    }
}
