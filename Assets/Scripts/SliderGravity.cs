using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderGravity : MonoBehaviour
{
    [SerializeField]
    private float gravityScale = 0.1f;

    private Slider slider = null;
    private bool m_Hold = false;
    private void OnEnable()
    {
        slider = GetComponent<Slider>();
        if (slider == null) Debug.Log("SliderGravity has no slider");
    }
    private void Update()
    {
        if (slider)
        {
            if (!m_Hold)
            {
                float mid = (slider.maxValue + slider.minValue) / 2;
                if (slider.value > mid) slider.value = Mathf.Lerp(slider.value, slider.maxValue, gravityScale);
                else slider.value = Mathf.Lerp(slider.value, slider.minValue, gravityScale);
            }
        }
    }
    public void SetHoldStatus(bool status)
    {
        m_Hold = status;
    }
}
