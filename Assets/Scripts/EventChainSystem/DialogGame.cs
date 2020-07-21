using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGame : EventBase
{
    [SerializeField]
    private EventBase next = null;
    [SerializeField]
    private GameObject DialogPrefab = null;

    private GameObject textObject;

    public override void InvokeEvent()
    {
        textObject = Instantiate(DialogPrefab, caster.transform);
        textObject.GetComponent<Text>().text = "...";
    }
    private void Complete()
    {
        Destroy(textObject);
        sys.AddQueue(next, true);
    }
}
