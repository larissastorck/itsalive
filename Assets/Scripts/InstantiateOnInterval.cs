using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnInterval : MonoBehaviour
{
    public float interval;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shot", interval, interval);
    }

    // Update is called once per frame
    void Shot()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
