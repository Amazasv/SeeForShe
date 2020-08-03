using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpScene : MonoBehaviour
{
    [SerializeField]
    private int m_ChapIndex = -1;
    [SerializeField]
    private int m_nextScene = 0;
    [SerializeField]
    private bool pressLock = true;

    private void OnEnable()
    {
        pressLock = true;
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
        if (m_ChapIndex == -1)
        {
            LevelManager.Instance.StartTransition(m_nextScene);
        }
        else LevelManager.Instance.StartSwitchChapter(m_ChapIndex);
    }

    public void Unlock()
    {
        if (pressLock == false) Debug.Log("repeat unlock");
        pressLock = false;
    }
}
