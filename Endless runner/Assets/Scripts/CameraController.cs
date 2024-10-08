using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 cameraVelocety;
    [SerializeField] float smoothTime = 1;
    [SerializeField] bool lookAtPlayer;
    [SerializeField] float offset = 2;
    void Update()
    {
        if (transform.position.y >= 1)
        {
            //smoothly Move the camera towards the player's Y position
            Vector3 targetPosition = new Vector3(transform.position.x, player.position.y + offset, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocety, smoothTime);
            //If the LookAtVariable is true the camera will look at the player
            if (lookAtPlayer == true)
            {
                transform.LookAt(player);
            }
        }
        else
        {
            cameraVelocety = new Vector3(0,0,0);
            transform.position = new Vector3(0, 1, -8);
        }
        
        
    }
}
