using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAndDestroyOnCollision : MonoBehaviour
{
    public GameObject PrefabToInstantiate;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(PrefabToInstantiate, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
