using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]

public class BtnPressResize : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    [Range(0, 1)]
    [SerializeField]
    private float size = 1;
    [SerializeField]
    private float time = 0.1f;

    private void Awake()
    {
        if (target == null) target = transform;
        GetComponent<Button>().onClick.AddListener(PressResize);
    }


    private void PressResize()
    {
        target.localScale = size * Vector3.one;
        CancelInvoke();
        Invoke(nameof(ResetSize), time);
    }

    private void ResetSize()
    {
        target.localScale = Vector3.one;
    }

}
