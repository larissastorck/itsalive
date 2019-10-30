using UnityEngine.Events;
using UnityEngine;
using System.Collections;

public class EnemyAttackTrigger : MonoBehaviour
{
    public UnityEvent AttackUnityEvent;
    public float AttackInterval;
    bool PlayerInRange = false;
    bool attacking = false;

    public bool stopPatrolMovementOnAttack = true;
    public PatrolMovement patrolMovement;
    Coroutine activeAttackCoroutine;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !attacking)
        {
            activeAttackCoroutine = StartCoroutine(AttackCorountine());
            PlayerInRange = true;
            attacking = true;
            if (stopPatrolMovementOnAttack)
            {
                patrolMovement.enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInRange = false;
            
            
        }
    }

    IEnumerator AttackCorountine()
    {
        while (true)
        {

            AttackUnityEvent.Invoke();
            yield return new WaitForSeconds(AttackInterval);
            if(!PlayerInRange)
            {
                attacking = false;
                if (stopPatrolMovementOnAttack)
                {
                    patrolMovement.enabled = true;
                }
                StopCoroutine(activeAttackCoroutine);
            }
        }
    }
}
