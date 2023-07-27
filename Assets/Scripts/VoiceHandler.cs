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
    public AudioClip[] music;
    public AudioSource musicPlayer;
    public TextMeshProUGUI weatherText;
    public Lights lights;

    int cubesSpawned = 0;
    int spheresSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        lights.LightsOff();
    }

    // Update is called once per frame
    void Update()
    {
        string musicPlayingText = musicPlayer.isPlaying ? musicPlayer.clip.name : "None";
        string lightsEnabledText = lights.on ? "Enabled" : "Disabled";
        weatherText.text = string.Format("Music Playing: {0}\nLights: {1}\nCubes Spawned: {2}\nSpheres Spawned: {3}", musicPlayingText, lightsEnabledText, cubesSpawned, spheresSpawned);
    }

    public void OnSpawn(string[] values){
        //weatherText.text = values[0];
        if(values[0] == "cube"){
            Instantiate(cube, new Vector3(SpawnLocation.transform.position.x,SpawnLocation.transform.position.y,SpawnLocation.transform.position.z),Quaternion.identity);
            cubesSpawned++;
        }
        else if(values[0] == "sphere")
        {
            Instantiate(sphere, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            spheresSpawned++;
        }
    }

    public void lightChange(string[] values)
    {
        //weatherText.text = values[0]; 
        if(values[0] == "lights on") {
            lights.LightsOn();
        } else if(values[0] == "lights off"){
            lights.LightsOff();
        }
    }

    public void playMusic(string[] values)
    {
        //weatherText.text = values[0];
        if(values[0] == "play music"){
            musicPlayer.clip = music[Random.Range(0, music.Length)];
            musicPlayer.Play();
        }
        if(values[0] == "stop music"){
            musicPlayer.Stop();
        }
    }

    public void deleteObject(string[] values)
    {
        if(values[0] == "delete object"){
            //weatherText.text = values[0];
            if (HoverBehaviour.hoveredObject != null && HoverBehaviour.hoveredObject.tag == "Deletable")
            {
                Destroy(HoverBehaviour.hoveredObject);
            }}
    }

}
