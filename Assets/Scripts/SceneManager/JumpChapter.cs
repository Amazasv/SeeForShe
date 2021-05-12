using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChapter : MonoBehaviour
{
    [SerializeField]
    private int index = 0;

    private ObjectLevel levelBase = null;

    private void Awake()
    {
        levelBase = GetComponentInParent<ObjectLevel>();
    }

    private void InstantTrans(UnityEngine.Playables.PlayableDirector obj)
    {
        levelBase.outDirector.stopped -= InstantTrans;
        GameManager.SwitchChapter(index);
    }

    public void ForceTransition()
    {
        //levelBase.OutTransition();
        //levelBase.outDirector.stopped += InstantTrans;
    }
}
