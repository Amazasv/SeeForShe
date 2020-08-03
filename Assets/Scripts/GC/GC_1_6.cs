using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_1_6 : MonoBehaviour
{
    [SerializeField]
    private GameObject mainScreen = null;
    [SerializeField]
    private GameObject appScreen = null;
    [SerializeField]
    private EventBase wrongEvent = null;

    private bool cd = false;
    private void OnEnable()
    {
        mainScreen.SetActive(true);
        appScreen.SetActive(false);
    }

    public void PressWrong()
    {
        if (!cd)
        {
            wrongEvent.InvokeEvent();
            cd = true;
        }
    }

    public void ResetCD()
    {
        cd = false;
    }

    public void PressRight()
    {
        if (!cd)
        {
            appScreen.SetActive(true);
        }
    }
}
