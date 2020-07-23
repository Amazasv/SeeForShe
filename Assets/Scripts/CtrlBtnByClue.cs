using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]

public class CtrlBtnByClue : MonoBehaviour
{
    [SerializeField]
    private int Index = 0;

    private Button btn = null;
    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    private void OnEnable()
    {
        GC_5.Instance.OnFlagChange.AddListener(UpdateButton);
        UpdateButton();
    }
    public void UpdateButton()
    {
        btn.interactable = GC_5.Instance.GetFlag(Index);
    }
    private void OnDisable()
    {
        GC_5.Instance.OnFlagChange.RemoveListener(UpdateButton);
    }
}
