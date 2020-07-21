using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCanvas : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // if (stateInfo.IsName("FadeIn")) GameManager.status = GameManager.StatusType.Fadein;
       // else if (stateInfo.IsName("Default")) GameManager.status = GameManager.StatusType.Default;
       // else if (stateInfo.IsName("FadeOut")) GameManager.status = GameManager.StatusType.Fadeout;
    }
}
