using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackAnimator : MonoBehaviour
{
    public UnityEvent AttackEvent;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            AttackEvent.Invoke();
            
        }
    }
}
