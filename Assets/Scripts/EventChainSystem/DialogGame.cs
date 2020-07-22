using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogGame : MonoBehaviour
{
    [SerializeField]
    private Transform caster=null;
    [SerializeField]
    private EventBase next = null;
    [SerializeField]
    private GameObject DialogPrefab = null;

    private GameObject textObject;

    public void InvokeEvent()
    {
        textObject = Instantiate(DialogPrefab, caster);
        textObject.GetComponent<Text>().text = "...";
    }
    private void Complete()
    {
        Destroy(textObject);
        //sys.AddQueue(next, true);
    }
}
