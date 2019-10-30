using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionTrigger : MonoBehaviour
    
    
{
    bool GhostOnTrigger = false;

    public GameObject EnemyGameObject;
    public GameObject PossessedPrefab;

    public GameObject PossesButtonGameObject;
    public Health HealthController;

    bool CanPossess = false;


    private void Start()
    {
        DamageEvent();
        HealthController.OnDamage += DamageEvent;
    }
    private void DamageEvent()
    {
   
        if (HealthController.health <= HealthController.maxHealth / 2f)
        {
            CanPossess = true;
        }
        else
        {
            CanPossess = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ghost ghost = collision.gameObject.GetComponent<Ghost>();
            if(ghost && CanPossess)
            {
                GhostOnTrigger = true;
                StartCoroutine(CheckPossessButton(ghost));
                PossesButtonGameObject.SetActive(true);


            }

       
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ghost ghost = collision.gameObject.GetComponent<Ghost>();
            if (ghost)
            {
                PossesButtonGameObject.SetActive(false);
                GhostOnTrigger = false;
            }



        }
    }

    IEnumerator CheckPossessButton(Ghost ghost)
    {
        
        while (GhostOnTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                PossesButtonGameObject.SetActive(false);
                ghost.Possess(PossessedPrefab, EnemyGameObject);
            }
            yield return null;
        }
    }


}
