using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Vector2 origin;
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rect.anchoredPosition = origin;
        canvasGroup.blocksRaycasts = true;
    }

    private void OnEnable()
    {
        origin = rect.anchoredPosition;
    }


}
