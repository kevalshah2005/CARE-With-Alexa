using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI utcText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI utcDateText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime now = DateTime.Now;
        timeText.text = now.ToShortTimeString();
        utcText.text = now.ToLocalTime().ToUniversalTime().ToShortTimeString() + " UTC";
        dateText.text = now.ToLongDateString();
        utcDateText.text = now.ToLocalTime().ToUniversalTime().ToLongDateString() + " UTC";
    }
}
