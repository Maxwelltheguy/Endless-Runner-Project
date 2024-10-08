using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCode : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}