using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpScene))]

public class GC_1_1 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Info2Spawn = null;
    [SerializeField]
    private GameObject hint = null;
    [SerializeField]
    private float time = 5.0f;

    private float timer = 5.0f;
    private int currentStep = 0;
    private InfoGroup infoManager = null;
    private JumpScene jump = null;

    private void Awake()
    {
        infoManager = GetComponentInChildren<InfoGroup>();
        jump = GetComponent<JumpScene>();
    }

    private void OnEnable()
    {
        if(hint) hint.SetActive(false);
        timer = time;
        currentStep = 0;
    }

    private void Update()
    {
        if(hint)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
                timer = time;
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                hint.SetActive(false);
            }
            else
            {
                hint.SetActive(true);

            }
        }
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
