using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    [SerializeField]
    private GameObject InfoBox = null;
    [SerializeField]
    private int MainPage = 0;
    private void OnEnable()
    {
        InfoBox.SetActive(false);
    }

    public void CallInfoBox(bool value)
    {
        InfoBox.SetActive(value);
    }

    public void Restart()
    {
        GameManager.Instance.SwitchChapter(MainPage);
    }
}
