using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessedEnemy : MonoBehaviour
{
    private GameObject ghost;
    private float force = 30.0f;
    private Rigidbody2D ghostRb;
    private Transform head;
    public GameObject ExplosionPrefab;
    public GameObject EnemyPrefab;
    Health health;

    void Start()
    {

        health = GetComponent<Health>();
        health.OnDie += DieEvent;

        head = gameObject.transform.Find("head");

    }

    public void Initialize(GameObject ghost, Health oldHealth)
    {
        this.ghost = ghost;
        ghostRb = ghost.GetComponent<Rigidbody2D>();
        if(health == null)
        {
            health = GetComponent<Health>();
            health.OnDie += DieEvent;
        }
        health.health = oldHealth.health;
        health.RefreshBar();


    }

    private void DieEvent()
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        ghost.transform.position = gameObject.transform.position;
        ghost.SetActive(true);
    }
    private void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Q))
        {
            health.DoDamage(1000);
            
            
            
            ghost.GetComponent<Ghost>().Unpossess();

        }
    }

    private void InstantiateEnemy()
    {
        gameObject.SetActive(false);
        GameObject x = Instantiate(EnemyPrefab, transform.position, transform.rotation);
        Health p = x.GetComponent<Health>();
        p.health = health.health;
        p.RefreshBar();
    }

    
}
