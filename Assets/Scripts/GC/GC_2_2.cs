using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GC_2_2 : MonoBehaviour
{
    [SerializeField]
    private ObjectLevel nextScene = null;
    [SerializeField]
    private float m_value = 0.33f;
    [SerializeField]
    private float stepLength = 0.05f;
    [SerializeField]
    private float dropSpeed = 0.05f;
    [SerializeField]
    private Slider processBar = null;
    [SerializeField]
    private GameObject hint = null;

    [SerializeField]
    private GameObject girl = null;
    [SerializeField]
    private GameObject boy = null;

    private Animator[] anims = null;


    private void Awake()
    {
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
        girl.transform.position = boy.transform.position + new Vector3(-2.0f, 0.0f, 0.0f) + new Vector3(-5.0f, 0.0f, 0.0f) * (1 - m_value);
    }

    private void GameFailed()
    {
        SwitchAllAnimation(false);
        LevelManager.instance.SetLevel(nextScene);
    }

    private void GameVictory()
    {
        GameManager.Instance.flags["catch"] = true;
        SwitchAllAnimation(false);
        if (hint) hint.SetActive(true);
    }

    private void SwitchAllAnimation(bool flag)
    {
        foreach (Animator anim in anims) anim.speed = flag ? 1.0f : 0.0f;
    }
}
