using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public bool isGrounded;
    int collidingPlatforms = 0;
    AudioSource audioSOurce;

    private void Start()
    {
        audioSOurce = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Platform"))
        {
            if(!isGrounded)
            {
                audioSOurce.Play();
                isGrounded = true;
            }
            collidingPlatforms++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            collidingPlatforms--;
            if(collidingPlatforms==0)
            {
                isGrounded = false;
            }
        }
    }
}
