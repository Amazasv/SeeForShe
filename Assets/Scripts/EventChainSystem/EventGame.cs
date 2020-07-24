using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(EventBase))]
public class EventGame : MonoBehaviour
{
    [SerializeField]
    private Transform gameAnchor = null;
    [SerializeField]
    private GameObject gamePrefab = null;
    [SerializeField]
    private EventBase next = null;
    [SerializeField]
    private Transform caster = null;
    [SerializeField]
    private GameObject DialogPrefab = null;

    private GameObject lastGame;
    private GameObject textObject;
    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
    }
    public void Fire()
    {
        textObject = Instantiate(DialogPrefab, caster);
        textObject.GetComponentInChildren<Text>().text = "...";
        if (lastGame == null)
        {
            lastGame = Instantiate(gamePrefab, gameAnchor);
            lastGame.GetComponent<DotsGC>().OnVictory.AddListener(Complete);
        }
    }
    private void Complete()
    {
        Destroy(textObject);
        Destroy(lastGame);
        GetComponentInParent<EventChainSystem>().FireEvent(next, 0.0f);
        //EventChainSystem.Instance.FireEvent(next, 0.0f);
    }
}
