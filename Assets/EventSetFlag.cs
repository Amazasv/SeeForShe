using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventBase))]
public class EventSetFlag : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
    }

    private void Fire()
    {
        GameManager.Instance.flag_get_help = true;
    }
}
