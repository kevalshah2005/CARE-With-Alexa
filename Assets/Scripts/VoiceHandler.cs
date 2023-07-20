using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceHandler : MonoBehaviour
{
    public GameObject cube;
    public GameObject SpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCube(){
        Instantiate(cube, new Vector3(SpawnLocation.transform.position.x,SpawnLocation.transform.position.y,SpawnLocation.transform.position.z),Quaternion.identity);
    }
}
