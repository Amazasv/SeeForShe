using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject caster;

    protected EventChainSystem sys;
    private void Awake()
    {
        sys = GetComponentInParent<EventChainSystem>();
        if (sys == null) Destroy(gameObject);
    }
    public abstract void InvokeEvent();
}
