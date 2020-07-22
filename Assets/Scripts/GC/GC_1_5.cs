using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_1_5 : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject appScreen;

    private void OnEnable()
    {
        mainScreen.SetActive(true);
        appScreen.SetActive(false);
    }
}
