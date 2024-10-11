using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int jumpHeight = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPos;
    public float distanceTraveled;
    [SerializeField] UIContoller uiController;
    public int collectedCoins;
    [SerializeField] bool airJump = false;
    [SerializeField] GameObject sheildPrefab;
    [SerializeField] SFXManager sfxManager;

    private void Start()
    {
        lastYPos = transform.position.y;
    }

    //Check For input and YPos for animation
    void Update()
    {
        distanceTraveled += Time.deltaTime;
        CheckForInput();
        FallAnim();
        
    }

    //Jumps when jump is true
    void FixedUpdate()
    {

        CheckForGrounded();

        if (jump == true)
        {
            Jump();
        }
    }

    //Declare the methods

    void CheckForInput()
    {
        if (isGrounded == true || airJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown((int)MouseButton.Left))
            {
                if(airJump == true && isGrounded == false)
                {
                    airJump = false;
                }
                jump = true;
                anim.SetTrigger("Jump");
            }
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
                anim.SetBool("is grounded", true);
                anim.SetBool("Falling", false);
            }
            else
            {
                isGrounded = false;
                anim.SetBool("is grounded", false);
                anim.SetBool("Falling", true);
            }
            //Debug.Log(hit.transform.name);
            //Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.yellow);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("is grounded", false);
            anim.SetBool("Falling", true);
        }
    }

    void FallAnim()
    {
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
        }
        else
        {
            anim.SetBool("Falling", false);
            
        }

        lastYPos = transform.position.y;
    }

    void Jump()
    {
        jump = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        sfxManager.PlaySFX("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("obstacle"))
        {
            sfxManager.PlaySFX("Hit");
            uiController.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            Destroy(collision.gameObject);
            sfxManager.PlaySFX("Coin");
        }
        if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            Destroy(collision.gameObject);

        }        
        if (collision.CompareTag("SheildPower"))
        {
            Instantiate(sheildPrefab, parent:transform);
            Destroy(collision.gameObject);

        }
    }
}
