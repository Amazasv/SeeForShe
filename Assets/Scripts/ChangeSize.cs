using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeSize : MonoBehaviour
{
    public bool hide = true;
    [SerializeField]
    private float speed = 0.03f;
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, hide ? Vector3.zero : Vector3.one, speed);
    }
    public void SetHide(bool value)
    {
        hide = value;
    }
}
