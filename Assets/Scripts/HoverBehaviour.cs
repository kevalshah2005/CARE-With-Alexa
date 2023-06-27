using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverBehaviour : MonoBehaviour
{
    public Outline outline;
    public bool hovering = false;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hovering && OVRInput.Get(OVRInput.Button.Two))
        {
            menu.SetActive(true);
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
