using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class MoodController : MonoBehaviour
{
    [SerializeField]
    private int m_Mood=0;
    [SerializeField]
    private bool m_talk=false;
    public int mood
    {
        get { return m_Mood; }
        set
        {
            if (animator)
            {
                m_Mood = value;
                animator.SetInteger("mood", value);
            }
        }
    }
    public bool talk
    {
        get { return m_talk; }
        set
        {
            if (animator)
            {
                m_talk = value;
                animator.SetBool("talk", value);
            }
        }
    }

    
    private  Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    

}
