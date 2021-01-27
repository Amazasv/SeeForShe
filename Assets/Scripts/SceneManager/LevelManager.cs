using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
public class LevelManager : MonoBehaviour
{
    public enum Mode
    {
        Normal,
        Debug
    }

    [SerializeField]
    private LevelBase m_StartScene = null;
    public LevelBase startScene
    {
        get { return m_StartScene; }
        set { m_StartScene = value; }
    }

    private List<LevelBase> m_LevelBases = new List<LevelBase>();

    public Mode mode;
    private void Start()
    {
        EnsureValidState();
    }

    public void RegisterLevel(LevelBase level)
    {
        if (!m_LevelBases.Contains(level))
            m_LevelBases.Add(level);
    }
    public void UnregisterLevel(LevelBase level)
    {
        if (m_LevelBases.Contains(level))
            m_LevelBases.Remove(level);
    }

    public void NotifyLevelOn(LevelBase level)
    {
        foreach (LevelBase i in m_LevelBases)
        {
            if (i == level) continue;
            i.gameObject.SetActive(false);
            if (i.BGM && i.BGM != level.BGM) i.BGM.Stop();
        }
    }

    public void EnsureValidState()
    {
        foreach (LevelBase tmp in m_LevelBases) tmp.gameObject.SetActive(false);
        if (startScene && m_LevelBases.Contains(startScene)) startScene.gameObject.SetActive(true);
        else if (m_LevelBases.Count > 0) m_LevelBases[0].gameObject.SetActive(true);
    }
}
