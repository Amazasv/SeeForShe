using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]

public class CtrlBtnByClue : MonoBehaviour
{
    [SerializeField]
    private int needClueIndex = 0;

    private Button btn = null;
    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    private void Update()
    {
        UpdateButton();
    }
    public void UpdateButton()
    {
        btn.interactable = GC_5.Instance.GetFlag(needClueIndex);
    }
}
