using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSlider : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] items = null;
    [Range(0.0f, 0.05f)]
    [SerializeField]
    private float moveSpeed = 0.05f;
    [SerializeField]
    private Vector2 sliderDir = Vector2.right;
    [SerializeField]
    private bool loop = true;

    private int currentItem = 0;
    private void ForceUpdateItem()
    {
        StopAllCoroutines();
        foreach (RectTransform i in items) i.gameObject.SetActive(false);
        items[currentItem].gameObject.SetActive(true);
        items[currentItem].anchorMin = items[currentItem].anchorMax = new Vector2(0.5f, 0.5f);
    }

    private void OnEnable()
    {
        ForceUpdateItem();
    }

    private void SwitchItem(int next, Vector2 dir)
    {
        dir.Normalize();
        ForceUpdateItem();
        items[next].gameObject.SetActive(true);
        items[next].anchorMin = items[next].anchorMax = new Vector2(0.5f, 0.5f) + dir;
        StartCoroutine(MoveIn(items[currentItem], new Vector2(0.5f, 0.5f) - dir, true));
        StartCoroutine(MoveIn(items[next], new Vector2(0.5f, 0.5f)));
        currentItem = next;
    }

    public void NextItem()
    {
        int next = currentItem + 1;
        if (next >= items.Length && !loop) return;
        else next %= items.Length;
        SwitchItem(next, sliderDir);
    }

    public void PrevItem()
    {
        int next = currentItem - 1;
        if (next < 0 && !loop) return;
        else next = (next + items.Length) % items.Length;
        SwitchItem(next, -sliderDir);
    }


    IEnumerator MoveIn(RectTransform rect, Vector2 target, bool disableOnArrival = false)
    {
        while (Vector2.Distance(rect.anchorMin, target) > 0.01f)
        {
            rect.anchorMin = rect.anchorMax = Vector2.MoveTowards(rect.anchorMin, target, moveSpeed);
            yield return 0;
        }
        rect.anchorMin = rect.anchorMax = target;
        if (disableOnArrival) rect.gameObject.SetActive(false);
    }

}
