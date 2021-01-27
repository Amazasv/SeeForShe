using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Swipe : MonoBehaviour
{
    private Vector2 pressPos;

    
    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;
    public UnityEvent OnClick;

    private void OnMouseDown()
    {
        pressPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseUp()
    {
        Vector2 releasePos= Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 dragVector = releasePos - pressPos;
        if (Vector2.Distance(releasePos, pressPos) > 0.3f)
        {
            float positiveX = Mathf.Abs(dragVector.x);
            float positiveY = Mathf.Abs(dragVector.y);
            if (positiveX > positiveY)
            {
                if (dragVector.x > 0)
                    OnSwipeRight.Invoke();
                else OnSwipeLeft.Invoke();
            }
        }
    }

    private void OnMouseUpAsButton()
    {
        OnClick.Invoke();
    }
}
