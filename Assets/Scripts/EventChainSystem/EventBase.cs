using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBase : MonoBehaviour
{
    public UnityEvent OnInvoke;
    private EventChainSystem sys;
    private void Awake()
    {
        sys = GetComponentInParent<EventChainSystem>();
        if (sys == null) Destroy(gameObject);
    }
    public void InvokeEvent()
    {
        //OnInvoke.Invoke(sys);
    }
}
