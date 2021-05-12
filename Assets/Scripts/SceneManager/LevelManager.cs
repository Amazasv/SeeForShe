using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; } = null;

    [SerializeField]
    private ObjectLevel m_StartScene = null;
    public ObjectLevel startScene
    {
        get { return m_StartScene; }
        set { m_StartScene = value; }
    }
    private List<ObjectLevel> m_LevelBases;
    private List<PlayableDirector> m_Directors;
    private ObjectLevel m_CurrentScene = null;
    private ObjectLevel m_NextScene = null;
    private int m_NextChapter = -1;

    private void Awake()
    {
        instance = this;
        m_LevelBases = new List<ObjectLevel>(GetComponentsInChildren<ObjectLevel>(true));
        m_Directors = new List<PlayableDirector>();
        foreach (ObjectLevel level in m_LevelBases)
            if (!m_Directors.Contains(level.outDirector))
                m_Directors.Add(level.outDirector);
        foreach (var dir in m_Directors)
            dir.stopped += OnAnimEnd;
    }

    private void Start()
    {
        foreach (ObjectLevel tmp in m_LevelBases) tmp.gameObject.SetActive(false);
        if (startScene && m_LevelBases.Contains(startScene))
        {
            startScene.gameObject.SetActive(true);
            m_CurrentScene = startScene;
            BGMManager.instance.current = startScene.BGM;
        }
        else if (m_LevelBases.Count > 0)
        {
            m_LevelBases[0].gameObject.SetActive(true);
            m_CurrentScene = m_LevelBases[0];
        }
    }

    private void OnAnimEnd(PlayableDirector obj)
    {
        SetChapter(m_NextChapter, false);
       SetLevel(m_NextScene, false);
    }

    public void SetLevel(ObjectLevel level, bool transition = true)
    {
        if (level == null) return;
        m_NextScene = level;
        if (transition)
        {
            BGMManager.instance.current = level.BGM;
            if (m_CurrentScene.outDirector) m_CurrentScene.outDirector.Play();
        }
        else
        {
            if(m_CurrentScene) m_CurrentScene.OnExit.Invoke();
            NotifyLevelOn(m_NextScene);
            m_NextScene.gameObject.SetActive(true);
            m_NextScene.OnEnter.Invoke();
            m_CurrentScene = m_NextScene;
            if (m_NextScene.inDirector)
                m_NextScene.inDirector.Play();
            m_NextScene = null;
        }
    }

    public void SetChapter(int index, bool transition = true)
    {
        if (index < 0) return;
        m_NextChapter = index;
        if (transition)
        {
            if (m_CurrentScene.outDirector) m_CurrentScene.outDirector.Play();
        }
        else
        {
            GameManager.SwitchChapter(m_NextChapter);
        }

    }

    public void NotifyLevelOn(ObjectLevel level)
    {
        foreach (ObjectLevel i in m_LevelBases)
        {
            if (i == level) continue;
            i.gameObject.SetActive(false);
        }
    }
}
