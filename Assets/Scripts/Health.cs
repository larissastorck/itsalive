using UnityEngine.UI;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int health = 10;
    public Slider hpSlider;
    private GameObject ghost;
    public event Action OnDie = delegate { };
    public event Action OnDamage = delegate { };
    public Image fillHpBar;
    public GameObject InstantiateOnDeath;

    private void Start()
    {
        ghost = GameObject.Find("dummy_ghost");
        RefreshBar();
        CheckForColorHpBar();
    }

    public void DoDamage(int x)
    {
        health -= x;
        hpSlider.value = (float)health / maxHealth;
        CheckForColorHpBar();
        OnDamage();
        if (health <= 0)
        {
            Die();
        }

    }

    void CheckForColorHpBar()
    {
        if (health <= maxHealth / 2)
        {
            fillHpBar.color = Color.red;
        }
       
    }



    public void RefreshBar()
    {
        if(hpSlider != null)
        hpSlider.value = (float)health / maxHealth;
    }

    void Die()
    {
        if(InstantiateOnDeath)
        {
            Instantiate(InstantiateOnDeath, transform.position, transform.rotation);
        }
        Destroy(gameObject);
        
        OnDie();
    }
}
