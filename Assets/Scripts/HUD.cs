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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime now = DateTime.Now;
        timeText.text = now.ToLongTimeString();
        utcText.text = now.ToLocalTime().ToUniversalTime().ToLongTimeString() + " UTC";
        dateText.text = now.ToLongDateString();
    }
}
