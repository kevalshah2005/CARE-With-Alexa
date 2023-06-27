using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioMenu : MonoBehaviour
{
    public GameObject menu;
    public Slider slider;
    public AudioClip[] music;
    public AudioSource audioSource;
    public int currentSong = 0;

    bool power = false;
    float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = volume;
        audioSource.clip = music[currentSong];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        volume = power ? slider.value : 0;

        audioSource.volume = volume;
    }

    public void powerPressed()
    {
        power = !power;
    }

    public void changeSongPressed()
    {
        currentSong++;
        if (currentSong >= music.Length)
        {
            currentSong = 0;
        }
        audioSource.clip = music[currentSong];
        audioSource.Play();
    }

    public void exitPressed()
    {
        menu.SetActive(false);
    }
}
