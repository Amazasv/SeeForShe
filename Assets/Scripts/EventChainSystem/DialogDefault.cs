using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogDefault : EventBase
{
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

    public override void InvokeEvent()
    {
        textObject = Instantiate(DialogPrefab, caster.transform);
        textObject.GetComponentInChildren<Text>().text = content;
        sys.AddQueue(next, false);
        if (hasLifeSpan) Destroy(textObject, existTime);
    }
}
