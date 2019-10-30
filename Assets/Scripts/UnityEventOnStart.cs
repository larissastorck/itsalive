using UnityEngine.Events;
using UnityEngine;

public class UnityEventOnStart : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("FadeToBlack").GetComponent<Animator>().SetTrigger("Fade"); 
    }

   
}
