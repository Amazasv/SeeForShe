using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChapter : MonoBehaviour
{
    [SerializeField]
    private int index = 0;

    private LevelBase levelBase = null;

    private void Awake()
    {
        levelBase = GetComponentInParent<LevelBase>();
    }

    private void InstantTrans(UnityEngine.Playables.PlayableDirector obj)
    {
        if (levelBase.BGM) levelBase.BGM.Stop();
        levelBase.outDirector.stopped -= InstantTrans;
        GameManager.Instance.SwitchChapter(index);
    }

    public void ForceTransition()
    {
        levelBase.OutTransition();
        levelBase.outDirector.stopped += InstantTrans;
    }
}
