using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenu : MonoBehaviour
{
    public HoverBehaviour hoverBehaviour;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hoverBehaviour.hovering && OVRInput.Get(OVRInput.Button.Two))
        {
            menu.SetActive(true);
        }
    }
}
