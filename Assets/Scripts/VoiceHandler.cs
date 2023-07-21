using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VoiceHandler : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    public GameObject SpawnLocation;
    public Light[] lights;
    public AudioClip[] music;
    public AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < lights.Length; x++)
        {
            lights[x] = lights[x].GetComponent<Light>();
            lights[x].enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSpawn(string[] values){
        if(values[0] == "cube"){
            Instantiate(cube, new Vector3(SpawnLocation.transform.position.x,SpawnLocation.transform.position.y,SpawnLocation.transform.position.z),Quaternion.identity);
        }
        else if(values[0] == "sphere")
        {
            Instantiate(sphere, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
        }
    }

    public void lightChange(string[] values)
    {
        //weatherText.text = values[0];
        for(int x = 0; x < lights.Length; x++)
        {
            if(values[0] == "lights on"){
                lights[x].enabled = true;
            }
            else if(values[0] == "lights off"){
                lights[x].enabled = false;
            }
        }
    }

    public void playMusic(string[] values)
    {
        musicPlayer.clip = music[Random.Range(0, music.Length)];
        musicPlayer.Play();
    }
}
