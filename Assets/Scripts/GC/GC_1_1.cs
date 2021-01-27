using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpScene))]

public class GC_1_1 : GCSequence
{
    [SerializeField]
    private GameObject[] Info2Spawn = null;
    [SerializeField]
    private GameObject hint = null;
    [SerializeField]
    private float time = 5.0f;

    private float timer = 5.0f;
    private InfoGroup infoManager = null;
    private JumpScene jump = null;

    private void Awake()
    {
        infoManager = GetComponentInChildren<InfoGroup>();
        jump = GetComponent<JumpScene>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (hint) hint.SetActive(false);
        timer = time;
    }

    private void Update()
    {
        if (hint)
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
        if (CurrentStep == Info2Spawn.Length - 1 && infoManager.transform.childCount == 0)
            jump.ForceTransition();
    }

    protected override void OnSwitchIn(int index)
    {
        infoManager.AddInfo(Info2Spawn[index]);
    }
}
