using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationByClue : MonoBehaviour
{
    [SerializeField]
    private int clueIndex = 0;
    [SerializeField]
    private bool sync = true;
    private void OnEnable()
    {
        UpdateVisuals();
    }
    private void Start()
    {
        GC_5.Instance.OnFlagChange.AddListener(UpdateVisuals);
    }

    public void UpdateVisuals()
    {
        gameObject.SetActive(!(sync ^ GC_5.Instance.GetFlag(clueIndex)));
    }
}
