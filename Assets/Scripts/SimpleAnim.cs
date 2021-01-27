using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class SimpleAnim:MonoBehaviour
{
    public virtual void Play()
    {
        StartCoroutine(Anim());
    }
    public virtual IEnumerator Anim() { yield return null; }
}
