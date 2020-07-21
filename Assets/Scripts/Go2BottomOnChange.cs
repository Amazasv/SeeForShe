using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
[RequireComponent(typeof(Scroll2Bottom))]
public class Go2BottomOnChange : MonoBehaviour
{
    private ScrollRect scroll;
    private Scroll2Bottom scroll2Bottom;

    private Vector2 lastSize = Vector2.zero;
    private RectTransform contentRect = null;
    private void Awake()
    {
        scroll = GetComponent<ScrollRect>();
        scroll2Bottom = GetComponent<Scroll2Bottom>();
        contentRect = scroll.content;
        scroll2Bottom.OnReach.AddListener(Disable2Bottom);
    }

    private void Disable2Bottom()
    {
        scroll2Bottom.enabled = false;
    }


    private void Update()
    {
        if (lastSize != contentRect.rect.size)
        {
            lastSize = contentRect.rect.size;
            scroll2Bottom.enabled = true;
        }
    }
}
