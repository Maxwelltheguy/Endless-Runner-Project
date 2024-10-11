using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCode : MonoBehaviour
{
    [SerializeField] SFXManager sfxManager;

    void Start()
    {
        sfxManager.PlaySFX("PowerupSheild");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            sfxManager.PlaySFX("SheildBreak");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}