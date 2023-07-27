using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCanvas : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectsByType<OVRPlayerController>(FindObjectsSortMode.None)[0].gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 awayDirection = transform.position - player.position;
        Quaternion awayRotation = Quaternion.LookRotation(awayDirection);
        transform.rotation = awayRotation;
    }
}
