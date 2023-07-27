using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverBehaviour : MonoBehaviour
{
    public Outline outline;
    public bool hovering = false;
    public static GameObject hoveredObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        outline.enabled = true;
        hovering = true;
        hoveredObject = gameObject;
    }

    public void OnPointerExit()
    {
        outline.enabled = false;
        hovering = false;
        hoveredObject = null;
    }

}
