using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressDetector : MonoBehaviour
{
    [SerializeField]
    private bool m_DefaultLock = true;
    public UnityEvent OnPress = null;


    private bool m_lock;
    private void OnEnable()
    {
        m_lock = m_DefaultLock;
    }
    private void Update()
    {
        if (!m_lock && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            OnPress.Invoke();
        }
    }
    public void Unlock()
    {
        m_lock = false;
    }
}
