using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GCSequence : MonoBehaviour
{
    private int m_CurrentStep=-1;
    public int CurrentStep
    {
        get
        {
            return m_CurrentStep;
        }
        set
        {
            OnSwitchOut(m_CurrentStep);
            m_CurrentStep = value;
            OnSwitchIn(m_CurrentStep);
        }
    }

    public void NextStep()
    {
        CurrentStep += 1;
    }

    protected virtual void OnEnable()
    {
        m_CurrentStep = -1;
    }

    protected virtual void OnSwitchIn(int index) { }
    protected virtual void OnSwitchOut(int index) { }
}
