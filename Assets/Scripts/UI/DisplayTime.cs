using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
//[ExecuteAlways]
public class DisplayTime : MonoBehaviour
{
    private int lastTime = 0;
    private Text text = null;
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if (GameManager.Instance.time != lastTime)
        {
            UpdateVisuals();
            lastTime = GameManager.Instance.time;
        }
    }

    private void UpdateVisuals()
    {
        text.text = Int2Clock(GameManager.Instance.time);
    }

    private string Int2Clock(int value)
    {
        return (value / 600).ToString() + (value / 60 % 10).ToString() + ":" + (value / 10 % 6).ToString() + (value % 10).ToString();
    }
}
