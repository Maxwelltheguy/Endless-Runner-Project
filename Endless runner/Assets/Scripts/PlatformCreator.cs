using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform refrencePoint;
    [SerializeField] private GameObject lastCreatedPlatform;
    [SerializeField] float spaceBetweenPlatforms = 2;
    float lastPlatformWidth;
    
    void Start()
    {
     //   lastCreatedPlatform = Instantiate(platformPrefab, refrencePoint.position, Quaternion.identity);
    }

    
    void Update()
    {
        if(lastCreatedPlatform.transform.position.x < refrencePoint.position.x)
        {
            Vector3 targetCreationPoint = new Vector3(refrencePoint.position.x + lastPlatformWidth + spaceBetweenPlatforms, refrencePoint.position.y, 0);
            int randomPlatform = Random.Range(0, 4);
            lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
