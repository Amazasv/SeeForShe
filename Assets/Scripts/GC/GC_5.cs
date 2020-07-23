using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GC_5 : MonoBehaviour
{
    public static GC_5 Instance = null;
    [SerializeField]
    private int maxTime = 21 * 60 + 30;
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

    void Update()
    {
        CheckTime();
    }

    public void CreateNewPage(GameObject prefab)
    {
        if (Time.time - lastTime > 0.5f)
        {
            Instantiate(prefab, pageManager);
            lastTime = Time.time;
        }
    }

    private void CheckTime()
    {
        if (GameManager.Instance.time >= maxTime) GameManager.Instance.SwitchChapter(5);
    }

    public void SetFlag(int index, bool value)
    {
        flagList[index] = value;
        OnFlagChange.Invoke();
    }

    public bool GetFlag(int index)
    {
        return flagList[index];
    }
}
