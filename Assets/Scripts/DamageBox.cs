using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBox : MonoBehaviour
{
    public int damage;
    public bool destroyOnDamage;

    public bool hitPlayer = true;
    public bool hitEnemies = true;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Health healthScript = other.gameObject.GetComponent<Health>();
        if(healthScript)
        {
            if(other.CompareTag("Player") && hitPlayer || other.CompareTag("Enemy") && hitEnemies)
            healthScript.DoDamage(damage);
            
            if(destroyOnDamage)
            {
                Destroy(gameObject);
            }
        }
    }
}
