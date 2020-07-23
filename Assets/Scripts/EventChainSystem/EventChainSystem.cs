using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventChainSystem : MonoBehaviour
{
    public static EventChainSystem Instance = null;

    [SerializeField]
    private float defaultGap = 2.0f;
    [SerializeField]
    private EventBase StartEvent = null;

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            AddQueue(StartEvent);
        }
        else Debug.Log("too many EventChainSystem");
    }

    public void AddQueue(EventBase target)
    {
        FireEvent(target, defaultGap);
    }

    public void FireEvent(EventBase target, float delay)
    {
        if (target)
        {
            StartCoroutine(CreateDialog(target, delay));
        }
        else
        {
            Debug.Log("null event");
        }
    }


    IEnumerator CreateDialog(EventBase dialog, float t)
    {
        yield return new WaitForSeconds(t);
        dialog.InvokeEvent();
    }

    private void OnDisable()
    {
        Instance = null;
        StopAllCoroutines();
    }
}
