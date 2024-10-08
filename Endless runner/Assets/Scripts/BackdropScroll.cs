using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdropScroll : MonoBehaviour
{
    SpriteRenderer rederer;
    [SerializeField] float speed = 1f;
    float offset = 0f;

    void Start()
    {
        rederer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        offset += Time.deltaTime * speed;
        rederer.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
