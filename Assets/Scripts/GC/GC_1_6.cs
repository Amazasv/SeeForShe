using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvent;
public class GC_1_6 : MonoBehaviour
{
    [SerializeField]
    private GameObject mainScreen = null;
    [SerializeField]
    private GameObject appScreen = null;
    [SerializeField]
    private EventBase wrongEvent = null;
    [SerializeField]
    private float cd = 1.0f;

    private float lastSpawn = 0.0f;
    private void OnEnable()
    {
        mainScreen.SetActive(true);
        appScreen.SetActive(false);
    }

    public void PressWrong()
    {
        if (Time.time - lastSpawn >= cd)
        {
            wrongEvent.InvokeEvent();
            lastSpawn = Time.time;
        }
    }

    public void PressRight()
    {
        appScreen.SetActive(true);
    }
}
