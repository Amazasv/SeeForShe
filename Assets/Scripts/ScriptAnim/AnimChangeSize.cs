using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimChangeSize : MonoBehaviour
{
    public bool on = false;
    [SerializeField]
    private float duration = 0.5f;
    public void SetOn(bool value)
    {
        on = value;
        StartCoroutine(Open(value));
    }

    private IEnumerator Open(bool on)
    {
        float f = 0f;
        while (f < duration)
        {
            if (on) transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, f / duration);
            else transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, 1.0f - f / duration);
            f += Time.deltaTime;
            yield return null;
        }
    }
}
