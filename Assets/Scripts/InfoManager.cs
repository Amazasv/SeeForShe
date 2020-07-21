using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 startAnchorMin = Vector2.zero;
    [SerializeField]
    private Vector2 startAnchorMax = Vector2.zero;
    [SerializeField]
    private float gap = 10.0f;
    [SerializeField]
    private float speed = 0.5f;

    private const float eps = 0.1f;

    private void OnEnable()
    {
        Clear();   
    }
    private void Update()
    {
        AutoLayout();
    }

    private void AutoLayout()
    {
        if (transform.childCount > 0)
        {
            RectTransform rect = transform.GetChild(0).GetComponent<RectTransform>();
            Vector2 targetPos = Vector2.right * rect.anchoredPosition;
            if (Mathf.Abs(rect.anchoredPosition.y) > 0.1f)
            {
                rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, targetPos, speed);
            }
            for (int i = 1; i < transform.childCount; i++)
            {
                rect = transform.GetChild(i).GetComponent<RectTransform>();
                targetPos = transform.GetChild(i - 1).GetComponent<RectTransform>().anchoredPosition + (gap + rect.rect.height) * Vector2.down;
                if (Vector2.Distance(rect.anchoredPosition, targetPos) > eps)
                {
                    rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, targetPos, speed);
                }
            }
        }
    }

    public void AddInfo(GameObject prefab)
    {
        GameObject tmp = Instantiate(prefab, transform);
        tmp.transform.SetAsFirstSibling();
        RectTransform rect = tmp.GetComponent<RectTransform>();
        rect.anchorMin = startAnchorMin;
        rect.anchorMax = startAnchorMax;
        rect.anchoredPosition = Vector2.zero;
    }

    private void Clear()
    {
        foreach (Transform tmp in transform) Destroy(tmp.gameObject);
    }

}
