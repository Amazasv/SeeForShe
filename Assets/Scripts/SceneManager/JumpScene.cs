using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpScene : MonoBehaviour
{
    [SerializeField]
    private LevelBase m_nextScene = null;

    private LevelBase levelBase = null;

    private void Awake()
    {
        levelBase = GetComponentInParent<LevelBase>();
    }

    private void InstantTrans(UnityEngine.Playables.PlayableDirector obj)
    {
        if (levelBase.BGM && levelBase.BGM != m_nextScene.BGM) levelBase.BGM.Stop();
        if (m_nextScene) m_nextScene.gameObject.SetActive(true);
        levelBase.outDirector.stopped -= InstantTrans;
    }

    public void ForceTransition()
    {
        levelBase.OutTransition();
        levelBase.outDirector.stopped += InstantTrans;
    }
}
