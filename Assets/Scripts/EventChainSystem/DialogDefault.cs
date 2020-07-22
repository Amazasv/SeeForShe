using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EventBase))]
public class DialogDefault : MonoBehaviour
{
    [SerializeField]
    private Transform caster=null;
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

    public void Fire(EventChainSystem sys)
    {
        textObject = Instantiate(DialogPrefab, caster);
        textObject.GetComponentInChildren<Text>().text = content;
        sys.AddQueue(next, false);
        if (hasLifeSpan) Destroy(textObject, existTime);
    }
}
