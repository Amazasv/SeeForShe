using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotationSlider : MonoBehaviour
{
    public RectTransform[] items = null;
    [SerializeField]
    private AnimationCurve m_InCurve = new AnimationCurve();
    [SerializeField]
    private AnimationCurve m_OutCurve = new AnimationCurve();
    [SerializeField]
    private float m_InDuration = 1.0f;
    [SerializeField]
    private float m_OutDuration = 1.0f;
    [SerializeField]
    private Vector2 sliderDir = Vector2.right;
    [SerializeField]
    private bool loop = true;

    private int m_Current = 0;

    public bool f=false;

    private void OnEnable()
    {
        FinishAnim();
    }

    private void SwitchItem(int next, Vector2 dir)
    {
        dir.Normalize();
        FinishAnim();
        items[next].gameObject.SetActive(true);
        items[next].anchorMin = items[next].anchorMax = new Vector2(0.5f, 0.5f) + dir;
        StartCoroutine(MoveIn(items[m_Current], new Vector2(0.5f, 0.5f) - dir, m_InCurve, m_InDuration, true));
        StartCoroutine(MoveIn(items[next], new Vector2(0.5f, 0.5f), m_OutCurve, m_OutDuration, f));
        m_Current = next;
    }

    public void NextItem()
    {
        if (m_Current == items.Length - 1 && !loop)
        {
            Debug.Log("there's no next item in " + this.ToString());
            return;
        }
        int next = m_Current + 1;
        if (next >= items.Length) next %= items.Length;
        SwitchItem(next, sliderDir);
    }

    public void PrevItem()
    {
        if (m_Current == 0 && !loop)
        {
            Debug.Log("there's no previous item in" + this.ToString());
            return;
        }
        int next = m_Current - 1;
        if (next < 0) next = (next + items.Length) % items.Length;
        SwitchItem(next, -sliderDir);
    }

    private void FinishAnim()
    {
        StopAllCoroutines();
        foreach (RectTransform i in items) i.gameObject.SetActive(false);
        items[m_Current].gameObject.SetActive(true);
        items[m_Current].anchorMin = items[m_Current].anchorMax = new Vector2(0.5f, 0.5f);
    }

    IEnumerator MoveIn(RectTransform rect, Vector2 target, AnimationCurve curve, float duration, bool disableOnArrival = false)
    {
        Vector2 startPos = rect.anchorMin;
        float startTime = Time.time;
        float currentTime = startTime;
        while (currentTime < startTime + duration)
        {
            float normal = curve.Evaluate((currentTime - startTime) / duration);
            rect.anchorMin = rect.anchorMax = (1.0f - normal) * startPos + normal * target;
            currentTime = Time.time;
            yield return 0;
        }
        rect.anchorMin = rect.anchorMax = target;
        if (disableOnArrival) rect.gameObject.SetActive(false);
    }

}
