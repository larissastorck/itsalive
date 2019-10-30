using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolMovement : MonoBehaviour
{
    bool goingRight = true;
    [SerializeField]
    public float speed;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float leftLimit;
    public bool log;

    public GameObject spriteObject;

    Health health;
    public Animator animator;



    private void Start()
    {
        health = GetComponent<Health>();
        health.OnDamage += TakeHit;
    }
    private void TakeHit()
    {
        animator.SetTrigger("Hit");
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingRight)
        {

            transform.Translate(speed * Time.deltaTime, 0, 0);

            if (log) Debug.Log(transform.position.x);

            if (transform.position.x > rightLimit)
            {
                if (log){
                    Debug.Log("maior que right limit");
       
                    Debug.Log(transform.position.x);
                }
                goingRight = !goingRight;
                spriteObject.transform.rotation = Quaternion.Euler(0, 180, 0);//(0, 0, 0)
                
            }
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < leftLimit)
            {
                if (log)
                {
                    Debug.Log("menor que right leftLimit");
                    Debug.Log(transform.position.x);
                }

                goingRight = !goingRight;
                spriteObject.transform.rotation = Quaternion.Euler(0, 0, 0);//(0, 180, 0)


            }
        }
    }




}
