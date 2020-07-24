using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EventBase))]
public class EventChangeSprite : MonoBehaviour
{
    [SerializeField]
    private Image target = null;
    [SerializeField]
    private Sprite sprite = null;

    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
    }


    private void Fire()
    {
        target.sprite = sprite;
    }
}
