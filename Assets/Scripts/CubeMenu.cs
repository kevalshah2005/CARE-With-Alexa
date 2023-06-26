using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMenu : MonoBehaviour
{
    public CubeOptions option = CubeOptions.NO_ACTION;
    public GameObject cube;
    public GameObject menu;
    public HoverBehaviour hoverBehaviour;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (option)
        {
            case CubeOptions.TRANSLATION:
                if (OVRInput.Get(OVRInput.RawButton.A) && hoverBehaviour.hovering)
                {
                    cube.transform.Translate(2 * Vector3.forward * Time.deltaTime);
                }
                break;

            case CubeOptions.ROTATION:
                if (OVRInput.Get(OVRInput.RawButton.A) && hoverBehaviour.hovering)
                {
                    cube.transform.Rotate(Vector3.up, 90f * Time.deltaTime);
                }
                break;

            case CubeOptions.NO_ACTION:
                break;
        }
    }

    public void translationPressed()
    {
        option = CubeOptions.TRANSLATION;
        exitPressed();
    }

    public void rotationPressed()
    {
        option = CubeOptions.ROTATION;
        exitPressed();
    }

    public void noActionPressed()
    {
        option = CubeOptions.NO_ACTION;
        exitPressed();
    }

    public void exitPressed()
    {
        menu.SetActive(false);
    }
}
