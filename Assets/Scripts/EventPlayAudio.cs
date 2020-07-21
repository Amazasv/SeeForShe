using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class EventPlayAudio : MonoBehaviour
{
    private AudioSource a = null;
    private void Awake()
    {
        a = GetComponent<AudioSource>();
    }
    public void PlayAudio()
    {
        a.Play();
    }
}
