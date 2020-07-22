using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EventBase))]
public class DialogDefault : MonoBehaviour
{
    [SerializeField]
    private Transform parent = null;
    [SerializeField]
    private bool hasLifeSpan = false;
    [SerializeField]
    private string content = "";
    [SerializeField]
    private EventBase next = null;
    [SerializeField]
    private float existTime = 2.0f;
    [SerializeField]
    private GameObject DialogPrefab = null;

    private GameObject textObject;

    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
    }

    public void Fire()
    {
        textObject = Instantiate(DialogPrefab, parent);
        textObject.GetComponentInChildren<Text>().text = content;
        EventChainSystem.Instance.AddQueue(next, false);
        if (hasLifeSpan) Destroy(textObject, existTime);
    }
}
