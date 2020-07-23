using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(EventBase))]
public class EventSwitch : MonoBehaviour
{

    //[SerializeField]
    //private bool hasLifeSpan = false;

    [Serializable]
    public class Branch
    {
        public EventBase next;
        public string desc;
    }
    [SerializeField]
    private Branch[] branches = null;
    [SerializeField]
    private GameObject btnPrefab = null;
    [SerializeField]
    private Transform btnCanvas = null;
    private List<GameObject> optionList = new List<GameObject>();

    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
    }

    public void Fire()
    {
        ShowOptions();
    }

    private void ShowOptions()
    {
        foreach (Branch branch in branches)
        {
            GameObject t = Instantiate(btnPrefab, btnCanvas);
            t.GetComponentInChildren<Text>().text = branch.desc;
            t.GetComponentInChildren<Button>().onClick.AddListener(delegate { Choose(branch.next); });
            optionList.Add(t);
        }
    }

    private void Choose(EventBase target)
    {
        foreach (GameObject tmp in optionList) Destroy(tmp);
        optionList.Clear();
        EventChainSystem.Instance.FireEvent(target, 0.0f);
    }
}
