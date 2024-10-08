using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentElement;
    [SerializeField] Transform refrencePoint;
    void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
        
    }

    IEnumerator CreateEnvironmentElement()
    {
        Instantiate(environmentElement[Random.Range(0, environmentElement.Length)], refrencePoint.position, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3,10));
        StartCoroutine(CreateEnvironmentElement());
    }
}
