using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationPlayer : MonoBehaviour
{
    private Animation anim=null;
    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    public void Play()
    {
        anim.Play();
    }
}
