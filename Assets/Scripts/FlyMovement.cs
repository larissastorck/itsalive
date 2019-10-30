using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    public float speed = 5;
    public SpriteRenderer SpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalAxisInput = Input.GetAxis("Horizontal");
        float VerticalAxisInput = Input.GetAxis("Vertical");
        transform.Translate(HorizontalAxisInput * Time.deltaTime * speed, VerticalAxisInput * Time.deltaTime * speed, 0);
        if (SpriteRenderer)
        {
            if (HorizontalAxisInput > 0 && SpriteRenderer.flipX)
            {
                SpriteRenderer.flipX = false;
            }
            else if (HorizontalAxisInput < 0 && !SpriteRenderer.flipX)
            {
                SpriteRenderer.flipX = true;
            }
        }

    }
}
