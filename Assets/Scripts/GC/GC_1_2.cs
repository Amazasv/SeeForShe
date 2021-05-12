using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class GC_1_2 : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director = null;
    [SerializeField]
    private AudioSource alarmAudio = null;
    public void PlayAudio()
    {
        alarmAudio.Play();
    }

    public void Press()
    {
        director.Resume();
        alarmAudio.Stop();
    }

}
