using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DotsGC : MonoBehaviour
{
    public class NodesNavigation
    {
        public GameObject icon;
        public Vector2Int Position;
        public NodesNavigation NodeOnUp;
        public NodesNavigation NodeOnDown;
        public NodesNavigation NodeOnLeft;
        public NodesNavigation NodeOnRight;
        public NodesNavigation(int x, int y)
        {
            icon = null;
            Position = new Vector2Int(x, y);
            NodeOnUp = NodeOnDown = NodeOnLeft = NodeOnRight = null;
        }
        public NodesNavigation(Vector2Int p)
        {
            icon = null;
            Position = p;
            NodeOnUp = NodeOnDown = NodeOnLeft = NodeOnRight = null;
        }
        ~NodesNavigation()
        {
            Destroy(icon);
        }
    }
    [SerializeField]
    private GameObject prefab = null;

    [SerializeField]
    private Vector2 gridSize = Vector2.zero;
    [SerializeField]
    private Vector2 spacing = Vector2.zero;
    //[SerializeField]
    //private Vector2 gap = Vector2.zero;
    [SerializeField]
    private int maxInRow = 3;
    [SerializeField]
    private Vector2Int startNodePosition = Vector2Int.zero;
    [SerializeField]
    private Vector2Int endNodePosition = Vector2Int.zero;
    [SerializeField]
    private Vector2Int[] defaultNodePosition = null;

    public UnityEvent OnVictory;

    private LineRenderer lineRenderer = null;
    private List<NodesNavigation> nodes = new List<NodesNavigation>();
    private List<NodesNavigation> pathRecord = new List<NodesNavigation>();
    private NodesNavigation currentNode = null;
    private NodesNavigation startNode = null;
    private NodesNavigation endNode = null;
    private void OnEnable()
    {
        ClearList();
        startNode = new NodesNavigation(startNodePosition);
        endNode = new NodesNavigation(endNodePosition);

        nodes.Add(startNode);
        nodes.Add(endNode);
        foreach (Vector2Int dot in defaultNodePosition) nodes.Add(new NodesNavigation(dot));


        CreateVisuals();
        CreateLinks();
        startNode.icon.GetComponent<SpriteRenderer>().color = Color.blue;
        endNode.icon.GetComponent<SpriteRenderer>().color = Color.green;

        currentNode = startNode;
        currentNode.icon.GetComponent<Animator>().SetBool("Beat", true);
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer)
        {
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, startNode.icon.transform.position);
        }
        else Debug.Log("LineRenderer is missing");
    }

    public void Swipe(TouchArea.DraggedDirection dir)
    {
        switch (dir)
        {
            case TouchArea.DraggedDirection.Up:
                if (currentNode.NodeOnUp != null)
                {
                    Jump(currentNode.NodeOnUp);
                }
                break;
            case TouchArea.DraggedDirection.Down:
                if (currentNode.NodeOnDown != null)
                {
                    Jump(currentNode.NodeOnDown);
                }
                break;
            case TouchArea.DraggedDirection.Right:
                if (currentNode.NodeOnRight != null)
                {
                    Jump(currentNode.NodeOnRight);
                }
                break;
            case TouchArea.DraggedDirection.Left:
                if (currentNode.NodeOnLeft != null)
                {
                    Jump(currentNode.NodeOnLeft);
                }
                break;
            default:
                break;
        }
    }

    private void ClearList()
    {
        foreach (NodesNavigation dot in nodes)
        {
            Destroy(dot.icon);
            dot.icon = null;
        }
        nodes.Clear();
    }

    private void CreateVisuals()
    {
        if (prefab)
        {
            foreach (NodesNavigation dot in nodes)
            {
                dot.icon = GameObject.Instantiate(prefab, transform);
                Transform trans = dot.icon.GetComponent<Transform>();
                trans.position = transform.position;
                Vector3 t = dot.Position * (gridSize + spacing) * new Vector2(1.0f, -1.0f);
                trans.position += t;
                trans.position -= (maxInRow - 1) * (gridSize.x + spacing.x) * Vector3.right / 2;
            }
        }
    }

    private void CreateLinks()
    {
        nodes.Sort((left, right) =>
                {
                    if (left.Position.x < right.Position.x) return -1;
                    else if (left.Position.x > right.Position.x) return 1;
                    else if (left.Position.y < right.Position.y) return -1;
                    else if (left.Position.y > right.Position.y) return 1;
                    else return 0;
                });
        for (int i = 1; i < nodes.Count; i++)
        {
            if (nodes[i].Position.x == nodes[i - 1].Position.x)
            {
                nodes[i - 1].NodeOnDown = nodes[i];
                nodes[i].NodeOnUp = nodes[i - 1];
            }
        }
        nodes.Sort((left, right) =>
        {
            if (left.Position.y < right.Position.y) return -1;
            else if (left.Position.y > right.Position.y) return 1;
            else if (left.Position.x < right.Position.x) return -1;
            else if (left.Position.x > right.Position.x) return 1;
            else return 0;
        });
        for (int i = 1; i < nodes.Count; i++)
        {
            if (nodes[i].Position.y == nodes[i - 1].Position.y)
            {
                nodes[i - 1].NodeOnRight = nodes[i];
                nodes[i].NodeOnLeft = nodes[i - 1];
            }
        }
    }

    private void Jump(NodesNavigation next)
    {
        if (next == endNode)
        {
            if (pathRecord.Count == nodes.Count - 2) OnVictory.Invoke();
            else return;
        }
        currentNode.icon.GetComponent<Animator>().SetBool("Beat", false);
        next.icon.GetComponent<Animator>().SetBool("Beat", true);
        pathRecord.Add(currentNode);
        if (currentNode.NodeOnDown != null) currentNode.NodeOnDown.NodeOnUp = currentNode.NodeOnUp;
        if (currentNode.NodeOnUp != null) currentNode.NodeOnUp.NodeOnDown = currentNode.NodeOnDown;
        if (currentNode.NodeOnLeft != null) currentNode.NodeOnLeft.NodeOnRight = currentNode.NodeOnRight;
        if (currentNode.NodeOnRight != null) currentNode.NodeOnRight.NodeOnLeft = currentNode.NodeOnLeft;
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, next.icon.transform.position);
        currentNode = next;
    }

    public void Undo()
    {
        NodesNavigation prev;
        if (pathRecord.Count > 0)
        {
            prev = pathRecord[pathRecord.Count - 1];
            prev.icon.GetComponent<Animator>().SetBool("Beat", true);
            currentNode.icon.GetComponent<Animator>().SetBool("Beat", false);
            if (currentNode.NodeOnDown != null) currentNode.NodeOnDown.NodeOnUp = currentNode;
            if (currentNode.NodeOnUp != null) currentNode.NodeOnUp.NodeOnDown = currentNode;
            if (currentNode.NodeOnLeft != null) currentNode.NodeOnLeft.NodeOnRight = currentNode;
            if (currentNode.NodeOnRight != null) currentNode.NodeOnRight.NodeOnLeft = currentNode;
            lineRenderer.positionCount--;
            currentNode = prev;
            pathRecord.Remove(prev);
        }
    }
}
