using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeScript : MonoBehaviour
{
    [SerializeField]
    private int value = 10;
    [SerializeField]
    private bool enableAddTime = false;
    private void OnEnable()
    {
        if (enableAddTime) AddTime();
    }

    public void AddTime()
    {
        GameManager.Instance.time += value;
    }
}
