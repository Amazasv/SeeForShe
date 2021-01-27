using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeArea : MonoBehaviour, IDragHandler,IEndDragHandler
{
    public enum DraggedDirection
    {
        Up=0,
        Down=1,
        Right=2,
        Left=3
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        SendMessageUpwards("Swipe", GetDragDirection(dragVectorDirection));
    }
    public static DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        return draggedDir;
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }
}

