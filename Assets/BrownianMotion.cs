using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownianMotion : MonoBehaviour
{

    public float xPeriod = 1.0f, yPeriod = 1.0f;
    public float xAmplitude = 1.0f, yAmplitude = 1.0f;
    public float xPhase = 0.0f, yPhase = 0.0f;
    private RectTransform rectTransform = null;
    private float time = 0;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        time += Time.deltaTime;
        float x = -xAmplitude * Mathf.Cos(xPhase + 2.0f * Mathf.PI * time / xPeriod);
        float y = yAmplitude * Mathf.Sin(yPhase + 2.0f * Mathf.PI * time / yPeriod);
        rectTransform.anchoredPosition += new Vector2(x, y);
    }
}
