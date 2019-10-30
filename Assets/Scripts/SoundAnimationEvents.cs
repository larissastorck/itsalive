using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundAnimationEvents : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySoundOneShot(AudioClip x)
    {
        audioSource.PlayOneShot(x);
    }
}
