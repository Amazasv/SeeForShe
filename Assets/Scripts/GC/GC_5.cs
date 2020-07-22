﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GC_5 : MonoBehaviour
{
    public static GC_5 Instance = null;
    [SerializeField]
    private bool[] flagList = new bool[20];
    [SerializeField]
    private Transform pageManager = null;

    public UnityEvent OnFlagChange;


    private float lastTime = 0;
    private void Awake()
    {
        Instance = this;
    }

    public void CreateNewPage(GameObject prefab)
    {
        if (Time.time - lastTime > 0.5f)
        {
            Instantiate(prefab, pageManager);
            lastTime = Time.time;
        }
    }

    public void SetFlag(int index,bool value)
    {
        flagList[index] = value;
        OnFlagChange.Invoke();
    }

    public bool GetFlag(int index)
    {
        return flagList[index];
    }

    //private void OnEnable()
    //{
    //    //clueCollected.Initialize();
    //}
}