using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
public class TLSequence : MonoBehaviour
{
    private PlayableDirector d=null;
    [SerializeField]
    private UnityEvent OnStop=null;
    private void Awake()
    {
        d = GetComponent<PlayableDirector>();
        d.stopped += delegate { OnStop.Invoke(); };
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            ResumeTimeline();
    }

    public void PauseTimeline()
    {
        d.Pause();
    }

    private void ResumeTimeline()
    {
        d.Resume();
    }    
}
