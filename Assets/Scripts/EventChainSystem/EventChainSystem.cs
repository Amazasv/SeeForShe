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
            AddQueue(StartEvent, false);
        }
        else Debug.Log("too many EventChainSystem");

    }

    public void AddQueue(EventBase dialog, bool immediate = false)
    {
        if (dialog == null)
        {
            Debug.Log("null event");
            return;
        }
        StartCoroutine(CreateDialog(dialog, immediate ? 0.0f : defaultGap));
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
