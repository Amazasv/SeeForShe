using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(JumpScene))]
public class GC_2_2 : MonoBehaviour
{
    [SerializeField]
    private float m_value = 0.33f;
    [SerializeField]
    private float stepLength = 0.05f;
    [SerializeField]
    private float dropSpeed = 0.05f;

    [SerializeField]
    private Slider processBar = null;
    [SerializeField]
    private Slider ImageBar = null;
    [SerializeField]
    private GameObject hint = null;

    private Animator[] anims = null;
    private JumpScene pressAnywhere = null;


    private void Awake()
    {
        pressAnywhere = GetComponent<JumpScene>();
        anims = GetComponentsInChildren<Animator>();
    }

    void Update()
    {
        if (m_value > 0.0f && m_value < 1.0f)
        {
            m_value = Mathf.Clamp01(m_value - dropSpeed * Time.deltaTime);
            UpdateVisuals();
            if (m_value == 0.0f) GameFailed();
        }
    }

    public void Add()
    {
        m_value = Mathf.Clamp01(m_value + stepLength);
        UpdateVisuals();
        if (m_value == 1.0f) GameVictory();
    }

    private void UpdateVisuals()
    {
        if (processBar) processBar.value = m_value;
        if (ImageBar) ImageBar.value = m_value;
    }

    private void GameFailed()
    {
        SwitchAllAnimation(false);
        pressAnywhere.ForceTransition();
    }

    private void GameVictory()
    {
        GameManager.Instance.globalFlags["catch"] = true;
        SwitchAllAnimation(false);
        if (hint) hint.SetActive(true);
    }

    private void SwitchAllAnimation(bool flag)
    {
        foreach (Animator anim in anims) anim.speed = flag ? 1.0f : 0.0f;
    }
}
