using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;
using Meta.WitAi.Json;

public class ActivateVoice : MonoBehaviour
{
    [SerializeField]
    private Wit wit;

    // Update is called once per frame
    private void Update()
    {
        if(wit == null) wit = GetComponent<Wit>();
        if(OVRInput.Get(OVRInput.Button.Four))
        {
            WitActivate();
        }
    }
    /*public void TriggerPressed(InputAction.CallbackContext context)
    {
        if(context.preformed)
            WitActivate();
    }*/
    public void WitActivate()
    {
        wit.Activate();
    }
}
