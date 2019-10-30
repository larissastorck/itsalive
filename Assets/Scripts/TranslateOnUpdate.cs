using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateOnUpdate : MonoBehaviour
{
    public Vector3 TranslateVector3;

    void Update()
    {
        transform.Translate(TranslateVector3 * Time.deltaTime);
    }
}
