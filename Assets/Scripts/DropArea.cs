using UnityEngine;
using UnityEngine.EventSystems;
public class DropArea : MonoBehaviour, IDropHandler
{
    private GC_1_3 gc;
    private void Awake()
    {
        gc = GetComponentInParent<GC_1_3>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable) gc.DropCheck(draggable);
    }

}
