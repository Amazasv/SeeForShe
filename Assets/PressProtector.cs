using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PressProtector : MonoBehaviour
{
    private CanvasGroup group = null;
    private float time = 2f;
    private void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        group.interactable = false;
        Invoke(nameof(Resume), time);
        
    }

    private void Resume()
    {
        group.interactable = true;
    }
}
