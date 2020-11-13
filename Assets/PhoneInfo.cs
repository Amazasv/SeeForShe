using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInfo : MonoBehaviour
{
    private InfoGroup group=null;
    private Animator anim=null;
    private void Awake()
    {
        group = GetComponentInParent<InfoGroup>();
        anim = GetComponentInParent<Animator>();
    }
    private void Start()
    {
        group.RegisterInfo(this);
    }
    private void OnDestroy()
    {
        group.UnRegisterInfo(this);
    }

    public void Clear()
    {
        anim.SetTrigger("destroy");
    }
}
