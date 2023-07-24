using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwitch : MonoBehaviour
{
    public Outline outline;
    public bool hovering = false;
    public Lights lights;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hovering && OVRInput.GetUp(OVRInput.Button.One))
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

    public void OnPointerEnter()
    {
        outline.enabled = true;
        hovering = true;
    }

    public void OnPointerExit()
    {
        outline.enabled = false;
        hovering = false;
    }

}
