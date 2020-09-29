using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class UIByClue : MonoBehaviour
{
    [SerializeField]
    private int clueIndex = 0;
    [SerializeField]
    private bool sync = true;
    [SerializeField]
    private bool ctrlAlpha = true;
    [SerializeField]
    private bool ctrlInteractable = true;
    [SerializeField]
    private bool ctrlRaycast = true;

    private CanvasGroup canvasGroup;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        UpdateVisuals();
        GC_5.Instance.OnFlagChange.AddListener(UpdateVisuals);
    }

    public void UpdateVisuals()
    {
        bool flag = !(sync ^ GC_5.Instance.GetFlag(clueIndex));
        if(ctrlAlpha) canvasGroup.alpha = flag ? 1.0f : 0.0f;
        if(ctrlRaycast)canvasGroup.blocksRaycasts = flag;
        if(ctrlInteractable) canvasGroup.interactable = flag;
    }
    private void OnDisable()
    {
        GC_5.Instance.OnFlagChange.RemoveListener(UpdateVisuals);
    }
}
