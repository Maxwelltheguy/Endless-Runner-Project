using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip sheildObtainSFX;
    [SerializeField] AudioClip getHitSFX;
    
    public void PlaySFX(string clipToPlay)
    {
        switch(clipToPlay)
        {
            case "Coin":
                audioSource.clip = coinSFX;
                break;
            case "Jump":
                audioSource.clip = jumpSFX;
                break;
            case "PowerupSheild":
                audioSource.clip = sheildObtainSFX;
                break;
            case "Hit":
                audioSource.clip = getHitSFX;
                break;
        }

        /*if(clipToPlay == "Coin")
        {
            audioSource.clip = coinSFX;
        }
        if(clipToPlay == "Jump")
        {
            audioSource.clip = jumpSFX;
        }
        if(clipToPlay == "PowerupSheild")
        {
            audioSource.clip = sheildObtainSFX;
        }
        if (clipToPlay == "Hit")
        {
            audioSource.clip = getHitSFX;
        }
        //if(clipToPlay == "Land")
        //{
        //    audioSource.clip = landSFX;
        //}*/

        audioSource.Play();
    }
}
