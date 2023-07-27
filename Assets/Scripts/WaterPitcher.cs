using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPitcher : MonoBehaviour
{
    public AudioClip waterFillSound;
    public AudioSource waterSoundSource;
    public GameObject water;
    public HoverBehaviour hoverBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hoverBehaviour.hovering && OVRInput.GetUp(OVRInput.Button.One) && !water.activeSelf)
        {
            waterSoundSource.clip = waterFillSound;
            waterSoundSource.Play();
            StartCoroutine(FillWater());
        }
    }

    public IEnumerator FillWater()
    {
        yield return new WaitUntil(() => !waterSoundSource.isPlaying);
        if (water != null)
        {
            water.SetActive(true);
        }
    }
}
