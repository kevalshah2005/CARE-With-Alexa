using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMenu : MonoBehaviour
{
    public SphereOptions option = SphereOptions.NO_ACTION;
    public GameObject sphere;
    public GameObject menu;
    public HoverBehaviour hoverBehaviour;
    bool previousAPressed = false;

    Color newColor = Color.red;
    Color oldColor = Color.grey;
    bool isColorNew = false;

    // Start is called before the first frame update
    void Start()
    {
        sphere.GetComponent<Renderer>().material.SetColor("_Color", oldColor);
    }

    // Update is called once per frame
    void Update()
    {
        switch (option)
        {
            case SphereOptions.CHANGE_COLOR:
                if (OVRInput.Get(OVRInput.RawButton.A) && !previousAPressed && hoverBehaviour.hovering)
                {
                    sphere.GetComponent<Renderer>().material.SetColor("_Color", isColorNew ? oldColor : newColor);
                    isColorNew = !isColorNew;
                }
                break;

            case SphereOptions.SCALING:
                if (OVRInput.Get(OVRInput.RawButton.A) && !previousAPressed && hoverBehaviour.hovering)
                {
                    sphere.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
                break;

            case SphereOptions.NO_ACTION:
                break;
        }

        previousAPressed = OVRInput.Get(OVRInput.RawButton.A);
    }

    public void changeColorPressed()
    {
        option = SphereOptions.CHANGE_COLOR;
        exitPressed();
    }

    public void scalingPressed()
    {
        option = SphereOptions.SCALING;
        exitPressed();
    }

    public void noActionPressed()
    {
        option = SphereOptions.NO_ACTION;
        exitPressed();
    }

    public void exitPressed()
    {
        menu.SetActive(false);
    }
}
