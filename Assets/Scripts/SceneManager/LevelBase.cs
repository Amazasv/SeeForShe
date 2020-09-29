using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;
using UnityEngine.Playables;
public class LevelBase : MonoBehaviour
{
    public AudioSource BGM;
    public PlayableDirector inDirector;
    public PlayableDirector outDirector;

    [SerializeField]
    private LevelManager m_LevelManager;
    private void Awake()
    {
        if (m_LevelManager == null) m_LevelManager = GetComponentInParent<LevelManager>();
        SetLevelManager(m_LevelManager);
        outDirector.stopped += ReactivateEventSys;
    }
    private void OnDestroy()
    {
        SetLevelManager(null);
        if (m_LevelManager != null)
            m_LevelManager.EnsureValidState();
    }
    private void OnEnable()
    {
        m_LevelManager.NotifyLevelOn(this);
        if (BGM && !BGM.isPlaying) BGM.Play();
        inDirector.Play();
    }

    public void OutTransition()
    {
        //EventSystem.current.enabled = false;
        outDirector.Play();
    }

    private void SetLevelManager(LevelManager newManager)
    {
        if (m_LevelManager != null)
            m_LevelManager.UnregisterLevel(this);
        if (newManager != null && gameObject.activeInHierarchy)
            newManager.RegisterLevel(this);
        if (newManager != null && gameObject.activeInHierarchy)
            newManager.NotifyLevelOn(this);
    }

    private void ReactivateEventSys(PlayableDirector obj)
    {
        //EventSystem.current.enabled = true;
    }
}
