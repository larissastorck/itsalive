using UnityEngine.SceneManagement;
using UnityEngine;

public class CutsceneAnimationEvents : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void PlayAudio(AudioClip x)
    {
        audioSource.clip = x;
        audioSource.Play();
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
    }
}
