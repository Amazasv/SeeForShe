using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageBase : MonoBehaviour
{
    private Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Close()
    {
        if (anim) anim.SetTrigger("Close");
        else Destroy(gameObject);
    }
}
