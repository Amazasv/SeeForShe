using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Slider))]
public class SliderGravity : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float gravityScale = 0.1f;

    private Slider slider = null;
    private bool m_Hold = false;
    private void OnEnable()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        if (!m_Hold)
        {
            float mid = (slider.maxValue + slider.minValue) / 2;
            if (slider.value > mid) slider.value = Mathf.Lerp(slider.value, slider.maxValue, gravityScale);
            else slider.value = Mathf.Lerp(slider.value, slider.minValue, gravityScale);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_Hold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_Hold = false;
    }
}
