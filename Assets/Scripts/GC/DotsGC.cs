using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
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
    }

    [SerializeField]
    private GameObject prefab = null;

    [SerializeField]
    private Vector2 gridSize = Vector2.zero;
    [SerializeField]
    private Vector2 spacing = Vector2.zero;
    [SerializeField]
    private float snap = 0.3f;
    [SerializeField]
    private int maxInRow = 3;
    [SerializeField]
    private Vector2Int startNodePosition = Vector2Int.zero;
    [SerializeField]
    private Vector2Int endNodePosition = Vector2Int.zero;
    [SerializeField]
    private Vector2Int[] defaultNodePosition = null;

    public UnityEvent OnVictory;

    public NodesNavigation currentNode
    {
        get { return m_CurrentNode; }
        set
        {
            if (m_CurrentNode == value) return;
            if (m_CurrentNode != null && m_CurrentNode.icon)
            {
                Animator anim = m_CurrentNode.icon.GetComponent<Animator>();
                if (anim) anim.SetBool("Beat", false);
            }
            if (value != null && value.icon)
            {
                Animator anim = value.icon.GetComponent<Animator>();
                if (anim) anim.SetBool("Beat", true);
            }
            m_CurrentNode = value;
        }
    }

    private LineRenderer lineRenderer = null;
    private readonly List<NodesNavigation> nodes = new List<NodesNavigation>();
    private readonly List<NodesNavigation> pathRecord = new List<NodesNavigation>();
    private NodesNavigation m_CurrentNode = null;
    private NodesNavigation startNode = null;
    private NodesNavigation endNode = null;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        CreateNode();
        CreateLinks();
        CreateVisuals();
        InitGame();
    }

    private void InitGame()
    {
        pathRecord.Clear();
        currentNode = startNode;
        pathRecord.Add(startNode);
    }

    private void CreateNode()
    {
        nodes.Add(startNode = new NodesNavigation(startNodePosition));
        nodes.Add(endNode = new NodesNavigation(endNodePosition));
        foreach (Vector2Int dot in defaultNodePosition) nodes.Add(new NodesNavigation(dot));
    }

    private void UpdateVisuals()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = pathRecord.Count + 1;
            for (int i = 0; i < pathRecord.Count; i++)
                lineRenderer.SetPosition(i, pathRecord[i].icon.transform.position);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(pathRecord.Count, mousePos);
        }
        else
        {
            lineRenderer.enabled = false;
        }

    }

    //public void Swipe(SwipeArea.DraggedDirection dir)
    //{
    //    switch (dir)
    //    {
    //        case SwipeArea.DraggedDirection.Up:
    //            if (m_CurrentNode.NodeOnUp != null)
    //            {
    //                Jump(m_CurrentNode.NodeOnUp);
    //            }
    //            break;
    //        case SwipeArea.DraggedDirection.Down:
    //            if (m_CurrentNode.NodeOnDown != null)
    //            {
    //                Jump(m_CurrentNode.NodeOnDown);
    //            }
    //            break;
    //        case SwipeArea.DraggedDirection.Right:
    //            if (m_CurrentNode.NodeOnRight != null)
    //            {
    //                Jump(m_CurrentNode.NodeOnRight);
    //            }
    //            break;
    //        case SwipeArea.DraggedDirection.Left:
    //            if (m_CurrentNode.NodeOnLeft != null)
    //            {
    //                Jump(m_CurrentNode.NodeOnLeft);
    //            }
    //            break;
    //        default:
    //            break;
    //    }
    //}

    private void Update()
    {
        Debug.Log(pathRecord[0].icon.transform.position);
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            NodesNavigation near = GetNearestNode(mousePos);
            if (near != null &&
                (near == currentNode.NodeOnDown
               || near == currentNode.NodeOnLeft
               || near == currentNode.NodeOnRight
               || near == currentNode.NodeOnUp))
                Jump(near);
        }
        else
        {
            Check();
            while (Undo()) ;
        }
        UpdateVisuals();
    }

    private NodesNavigation GetNearestNode(Vector2 pos)
    {
        NodesNavigation ans = startNode;
        float dis = Vector2.Distance(ans.icon.transform.position, pos);
        foreach (NodesNavigation dot in nodes)
            if (Vector2.Distance(dot.icon.transform.position, pos) < dis)
            {
                ans = dot;
                dis = Vector2.Distance(dot.icon.transform.position, pos);
            }
        if (dis < snap)
            return ans;
        else return null;
    }

    private void Check()
    {
        if (pathRecord.Count == nodes.Count) 
            OnVictory.Invoke();
        else return;
    }

    private void CreateVisuals()
    {
        if (prefab)
        {
            foreach (NodesNavigation dot in nodes)
            {
                dot.icon = Instantiate(prefab, transform);
                Transform trans = dot.icon.GetComponent<Transform>();
                trans.position = transform.position;
                Vector3 t = dot.Position * (gridSize + spacing) * new Vector2(1.0f, -1.0f);
                trans.position += t;
                trans.position -= (maxInRow - 1) * (gridSize.x + spacing.x) * Vector3.right / 2;
            }
            startNode.icon.GetComponent<SpriteRenderer>().color = Color.blue;
            endNode.icon.GetComponent<SpriteRenderer>().color = Color.green;
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
        if (currentNode.NodeOnDown != null) currentNode.NodeOnDown.NodeOnUp = currentNode.NodeOnUp;
        if (currentNode.NodeOnUp != null) currentNode.NodeOnUp.NodeOnDown = currentNode.NodeOnDown;
        if (currentNode.NodeOnLeft != null) currentNode.NodeOnLeft.NodeOnRight = currentNode.NodeOnRight;
        if (currentNode.NodeOnRight != null) currentNode.NodeOnRight.NodeOnLeft = currentNode.NodeOnLeft;
        currentNode = next;
        pathRecord.Add(m_CurrentNode);
    }

    public bool Undo()
    {
        if (pathRecord.Count > 1)
        {
            NodesNavigation prev = pathRecord[pathRecord.Count - 2];
            if (prev.NodeOnDown != null) prev.NodeOnDown.NodeOnUp = prev;
            if (prev.NodeOnUp != null) prev.NodeOnUp.NodeOnDown = prev;
            if (prev.NodeOnLeft != null) prev.NodeOnLeft.NodeOnRight = prev;
            if (prev.NodeOnRight != null) prev.NodeOnRight.NodeOnLeft = prev;
            pathRecord.Remove(currentNode);
            currentNode = prev;
            return true;
        }
        else return false;
    }
}
