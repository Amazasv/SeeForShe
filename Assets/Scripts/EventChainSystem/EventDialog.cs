using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EventBase))]
public class EventDialog : MonoBehaviour
{
    [SerializeField]
    private Talking talking = null;
    [SerializeField]
    private bool dontDestroy = false;
    [SerializeField]
    private string content = "";
    [SerializeField]
    private float existTime = 2.0f;

    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
    }

    public void Fire()
    {
        talking.Speak(content);
        if (!dontDestroy) talking.ForceClear(existTime);
    }
}
