using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(EventBase))]
public class EventSwitch : MonoBehaviour
{
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
    private Canvas btnCanvas = null;

    private HorizontalOrVerticalLayoutGroup layout = null;
    private List<GameObject> optionList = new List<GameObject>();

    private void Awake()
    {
        GetComponent<EventBase>().OnInvoke.AddListener(Fire);
        layout = btnCanvas.GetComponentInChildren<HorizontalOrVerticalLayoutGroup>();
        btnCanvas.gameObject.SetActive(false);
    }

    public void Fire()
    { 
        ShowOptions();
    }

    private void ShowOptions()
    {
        btnCanvas.gameObject.SetActive(true);
        foreach (Branch branch in branches)
        {
            GameObject t = Instantiate(btnPrefab, layout.transform);
            t.GetComponentInChildren<Text>().text = branch.desc;
            t.GetComponentInChildren<Button>().onClick.AddListener(delegate { Choose(branch.next); });
            optionList.Add(t);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(layout.GetComponent<RectTransform>());
    }

    private void Choose(EventBase target)
    {
        btnCanvas.gameObject.SetActive(false);
        foreach (GameObject tmp in optionList) Destroy(tmp);
        optionList.Clear();
        GetComponentInParent<EventChainSystem>().FireEvent(target, 0.0f);
        //EventChainSystem.Instance.FireEvent(target, 0.0f);
    }
}
