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
    private JumpScene pressAnywhere = null;

    private void Awake()
    {
        infoManager = GetComponentInChildren<InfoManager>();
        pressAnywhere = GetComponent<JumpScene>();
    }

    private void OnEnable()
    {
        currentStep = 0;
    }

    public void AddInfo()
    {
        if (currentStep < Info2Spawn.Length)
        {
            infoManager.AddInfo(Info2Spawn[currentStep++]);
        }
    }
}
