using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip jumpSFX;
    
    
    public void PlaySFX(string clipToPlay)
    {
        if(clipToPlay == "Coin")
        {
            audioSource.clip = coinSFX;
        }
        if(clipToPlay == "Jump")
        {
            audioSource.clip = jumpSFX;
        }
        //if(clipToPlay == "Land")
        //{
        //    audioSource.clip = landSFX;
        //}

        audioSource.Play();
    }
}
