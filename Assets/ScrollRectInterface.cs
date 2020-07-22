using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteAlways]
public class ScrollRectInterface : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float VerticalNormalizedPosition = 0.0f;

    private ScrollRect scrollRect;

    private void OnEnable()
    {
        VerticalNormalizedPosition = 1.0f;
    }
    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollRect.verticalNormalizedPosition = VerticalNormalizedPosition;   
    }
}
