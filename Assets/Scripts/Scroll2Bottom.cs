using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Scroll2Bottom : MonoBehaviour
{
    public UnityEvent OnReach;
    private ScrollRect scrollRect;

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    void Update()
    {
        if (!CheckInBottom())
        {
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, 0.0f, 0.05f);
            if (CheckInBottom())
            {
                OnReach.Invoke();
                scrollRect.verticalNormalizedPosition = 0.0f;
            }
        }
    }

    public bool CheckInBottom()
    {
        return scrollRect.verticalNormalizedPosition <= 0.01f;
    }
}
