using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressDetector : MonoBehaviour
{
    public bool m_Lock = true;
    public UnityEvent OnPress = null;
    private void OnEnable()
    {
        m_Lock = true;
    }
    private void Update()
    {
        if (!m_Lock && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            OnPress.Invoke();
        }
    }
    public void Unlock()
    {
        m_Lock = false;
    }
}
