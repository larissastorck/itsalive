using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", timeToDestroy);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
