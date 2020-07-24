using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EventBase))]
public class EventAutoFire : MonoBehaviour
{
    [SerializeField]
    private EventBase next = null;
    [SerializeField]
    private float delay = 2.0f;

    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
    }

    private void Fire()
    {
        GetComponentInParent<EventChainSystem>().FireEvent(next, delay);
      //  EventChainSystem.Instance.FireEvent(next, delay);
    }
}
