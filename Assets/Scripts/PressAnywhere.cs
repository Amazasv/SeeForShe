using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnywhere : MonoBehaviour
{
    [SerializeField]
    private int m_nextScene = 0;
    //[SerializeField]
    //private int m_nextChapter = -1;
    [SerializeField]
    private bool pressLock = true;

    private bool defaultLock;

    private void Awake()
    {
        defaultLock = pressLock;
    }

    private void OnEnable()
    {
        pressLock = defaultLock;
    }

    private void Update()
    {
        if (!pressLock && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            ForceTransition();
        }
    }

    public void ForceTransition()
    {
        LevelManager.Instance.StartTransition(m_nextScene);
    }

    public void Unlock()
    {
        if (defaultLock == false) Debug.Log("unneccesary unlock");

        pressLock = false;
    }
}
