using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MonitorPageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GetClue = null;
    public void EnableClue()
    {
        if (GetClue) GetClue.SetActive(true);
    }

    public void CloseClue()
    {
        GetClue.SetActive(false);
    }

}
