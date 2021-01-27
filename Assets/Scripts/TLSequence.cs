using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
public class TLSequence : MonoBehaviour
{
    private PlayableDirector d = null;
    private void Awake()
    {
        d = GetComponent<PlayableDirector>();
    }

    public void PauseTimeline()
    {
        d.Pause();
    }

    public void ResumeTimeline()
    {
        d.Resume();
    }
}
