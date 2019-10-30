using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
#if UNITY_EDITOR
    [TextArea]
    public string DevNote = "Esse componente não chama nenhuma função por si só, sendo preciso que outro script ou um unityEvent chame a função";
#endif
    public GameObject PrefabToInstantiate;

    // Start is called before the first frame update
    public void InstantiatePrefab()
    {
        Instantiate(PrefabToInstantiate, transform.position, transform.rotation);
    }
}
