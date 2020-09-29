using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class Go2BottomOnChange : MonoBehaviour
{
    private ScrollRect scroll;

    private Vector2 lastSize = Vector2.zero;
    private RectTransform contentRect = null;
    private void Awake()
    {
        scroll = GetComponent<ScrollRect>();
        contentRect = scroll.content;
    }
    private void Update()
    {
        if (lastSize != contentRect.rect.size)
        {
            lastSize = contentRect.rect.size;
            StopCoroutine(Scroll2Bottom());
            StartCoroutine(Scroll2Bottom());
        }
    }

    private IEnumerator Scroll2Bottom()
    {
        while (scroll.verticalNormalizedPosition > 0.001f)
        {
            scroll.verticalNormalizedPosition = Mathf.Lerp(scroll.verticalNormalizedPosition, 0.0f, 0.05f);
            yield return 0;
        }
        scroll.verticalNormalizedPosition = 0.0f;
    }
}
