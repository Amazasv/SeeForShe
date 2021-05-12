using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PressDetector))]
public class AutoUnlock : MonoBehaviour
{
    [SerializeField]
    private float delay = 1.5f;
    private PressDetector detector = null;
    private void Awake()
    {
        detector = GetComponent<PressDetector>();
    }
    private void OnEnable()
    {
        detector.enabled = false;
        Invoke(nameof(Unlock), delay);
    }

    private void Unlock()
    {
        detector.enabled = true;
    }
}
