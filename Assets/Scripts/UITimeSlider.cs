using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class UITimeSlider : MonoBehaviour
{
    private Slider slider = null;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        slider.value = 1 - (GameManager.Instance.time - (15 * 60 + 30)) / (1.0f * 6 * 60);
    }
}
