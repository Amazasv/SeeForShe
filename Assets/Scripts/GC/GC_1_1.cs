using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpScene))]

public class GC_1_1 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Info2Spawn = null;

    private int currentStep = 0;
    private InfoManager infoManager = null;
    private JumpScene jump = null;

    private void Awake()
    {
        infoManager = GetComponentInChildren<InfoManager>();
        jump = GetComponent<JumpScene>();
    }

    private void OnEnable()
    {
        currentStep = 0;
    }

    private void Update()
    {
        UpdateVisuals();
    }
    public void UpdateVisuals()
    {
        if (currentStep == Info2Spawn.Length && infoManager.transform.childCount == 0)
            jump.ForceTransition();
    }

    public void AddInfo()
    {
        if (currentStep < Info2Spawn.Length)
        {
            infoManager.AddInfo(Info2Spawn[currentStep++]);
        }
    }
}
