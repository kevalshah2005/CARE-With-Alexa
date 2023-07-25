using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public Outline outline;
    public bool hovering = false;
    public AudioClip waterEmptySound;
    public AudioSource waterSoundSource;
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hovering && OVRInput.GetUp(OVRInput.Button.One) && water.activeSelf)
        {
            waterSoundSource.clip = waterEmptySound;
            waterSoundSource.Play();
            StartCoroutine(EmptyWater());
        }
    }

    public void OnPointerEnter()
    {
        outline.enabled = true;
        hovering = true;
    }

    public void OnPointerExit()
    {
        outline.enabled = false;
        hovering = false;
    }

    public IEnumerator EmptyWater()
    {
        yield return new WaitUntil(() => !waterSoundSource.isPlaying);
        if (water != null)
        {
            water.SetActive(false);
        }
    }
}
