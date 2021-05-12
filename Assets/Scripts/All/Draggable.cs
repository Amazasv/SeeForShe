using UnityEngine;
using UnityEngine.Events;
public class Draggable : MonoBehaviour
{
    [SerializeField]
    private bool useBounds = false;
    [SerializeField]
    private Bounds bounds;
    [SerializeField]
    private bool sendBack = true;

    private Vector3 origin;
    private Vector2 offset;

    public UnityEvent onDrop = new UnityEvent();

    private SpriteRenderer thisRender;

    private void Awake()
    {
        origin = transform.position;
        thisRender = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Vector2 pos = transform.position;
        offset = pos - CalcPosition();
    }

    void OnMouseDrag()
    {
        if (thisRender)
        {
            thisRender.sortingLayerName = "WorldUI";
        }
        Vector2 newPos= CalcPosition() + offset;
        if (useBounds && !bounds.Contains(newPos)) newPos = bounds.ClosestPoint(newPos);
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        if (thisRender)
            thisRender.sortingLayerName = "Default";
        onDrop.Invoke();
        if(sendBack) transform.position = origin;
    }

    private Vector2 CalcPosition()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        return curPosition;
    }
}
