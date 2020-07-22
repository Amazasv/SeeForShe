using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DialogBranches : MonoBehaviour
{
    [SerializeField]
    private Transform caster = null;
    [SerializeField]
    private bool hasLifeSpan = false;

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
    [SerializeField]
    protected GameObject DialogPrefab = null;

    private GameObject textObject;
    private List<GameObject> optionList = new List<GameObject>();
    public void Fire()
    {
        ShowMessage();
        ShowOptions();
    }
    private void ShowMessage()
    {
        if (DialogPrefab)
        {
            textObject = Instantiate(DialogPrefab, caster.transform);
            textObject.GetComponent<Text>().text = "...";
        }
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
        if (hasLifeSpan) Destroy(textObject);
        //sys.AddQueue(target, true);
    }
}
