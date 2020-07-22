using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeScript : MonoBehaviour
{
    [SerializeField]
    private int value = 10;
    [SerializeField]
    private bool AddOnEnable = false;
    private void OnEnable()
    {
        if (AddOnEnable) AddTime();
    }

    public void AddTime()
    {
        GameManager.Instance.time += value;
    }
}
