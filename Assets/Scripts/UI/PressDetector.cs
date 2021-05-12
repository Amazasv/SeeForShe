using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressDetector : MonoBehaviour
{
    public UnityEvent OnPress = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            OnPress.Invoke();
        }
    }
}
