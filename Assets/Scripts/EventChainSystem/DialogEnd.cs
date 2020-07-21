using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogEnd : EventBase
{
    [SerializeField]
    private UnityEvent OnInvoke = null;
    public override void InvokeEvent()
    {
        OnInvoke.Invoke();
    }
}
