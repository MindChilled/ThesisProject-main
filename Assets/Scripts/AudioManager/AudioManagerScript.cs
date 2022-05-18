using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] AudioClip pickupSFX;
    [SerializeField] AudioClip dropSFX;

    public void PlayPickupSFX()
    {
        Debug.Log("Playing pickup");
        audioSource.clip = pickupSFX;
        audioSource.Play();
        //audioSource.clip = null;
    }

    public void PlayDropSFX()
    {
        audioSource.clip = dropSFX;
        audioSource.Play();
        //audioSource.clip = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
