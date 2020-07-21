using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SliderNoJump : Slider
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(handleRect, eventData.pointerPressRaycast.screenPosition, eventData.enterEventCamera))
        {
            Debug.Log("?");
            base.OnPointerDown(eventData);
        }
        else
        {
            Debug.Log("!");
        }
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }
}
