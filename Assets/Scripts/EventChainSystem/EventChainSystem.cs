using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventChainSystem : MonoBehaviour
{
    [SerializeField]
    private float defaultGap = 2.0f;
    [SerializeField]
    private EventBase StartEvent = null;

    private void OnEnable()
    {
        AddQueue(StartEvent, false);
    }

    public void AddQueue(EventBase dialog, bool immediate = false)
    {
        StartCoroutine(CreateDialog(dialog, immediate ? 0.0f : defaultGap));
    }

    IEnumerator CreateDialog(EventBase dialog, float t)
    {
        yield return new WaitForSeconds(t);
        dialog.InvokeEvent();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
