using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider2D))]

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public abstract class MiniGame : MonoBehaviour
{
    public MyIntEvent OnInput = new MyIntEvent();
    public MyIntEvent OnEnd = new MyIntEvent();
    [SerializeField]
    protected float AIdelay = 2f;
    [SerializeField]
    private bool m_Running = false;

    public bool running
    {
        get { return m_Running; }
        set 
        { 
            m_Running = value;
            UpdateVisuals();
        }
    }

    public abstract void UpdateVisuals();
}


public class TicTacToe : MiniGame
{
    [SerializeField]
    private GameObject m_PiecePrefab_0=null;
    [SerializeField]
    private GameObject m_PiecePrefab_1=null;



    private BoxCollider2D m_ThisCollider;

    private readonly int[] m_Data = new int[9];
    private readonly GameObject[] m_Pieces = new GameObject[9];
    private bool m_EnableInput = false;
    private bool m_Running = false;
    private int m_Count = 0;
    
    private void Awake()
    {
        m_ThisCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InitGame();
    }

    private void OnMouseUpAsButton()
    {
        if (!m_EnableInput || !m_Running)
        {
            Debug.Log("现在不能放置棋子");
            return;
        }
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float minX = (mousePos - m_ThisCollider.bounds.min).x;
        float minY = (mousePos - m_ThisCollider.bounds.min).y;
        float width = m_ThisCollider.size.x;
        float height = m_ThisCollider.size.y;
        int indexX = Mathf.FloorToInt(minX * 3f / width);
        int indexY = Mathf.FloorToInt(minY * 3F / height);
        if (PlayerInput(indexX + 3 * indexY, 0))
        {
            m_EnableInput = false;
            if (m_Running)
            {
                Invoke(nameof(AIMove), AIdelay);
            }
        }
    }

    public bool PlayerInput(int index, int side)
    {
        if (index < 0 || index >= 9)
        {
            Debug.LogError("非法格子输入");
            return false;
        }
        if (m_Data[index] != -1)
        {
            Debug.Log("当前格子已有棋子");
            return false;
        }
        m_Data[index] = side;
        m_Count++;
        UpdateVisuals();
        OnInput.Invoke(side);
        Debug.Log(side.ToString()+"类棋子放置于第" + index.ToString() + "号格子");
        if (CheckWin(m_Data, index))
        {
            OnEnd.Invoke(side);
            m_Running = false;
        }
        else if (m_Count == 9)
        {
            OnEnd.Invoke(-1);
            m_Running = false;
        }
        return true;
    }

    public static bool CheckWin(int[] data, int index)
    {
        int row = index / 3;
        int col = index % 3;
        if (data[row * 3] == data[row * 3 + 1] && data[row * 3] == data[row * 3 + 2]) return true;
        if (data[col] == data[3 + col] && data[col] == data[6 + col]) return true;
        if (data[0] != -1 && data[0] == data[4] && data[4] == data[8]) return true;
        if (data[2] != -1 && data[2] == data[4] && data[4] == data[6]) return true;
        return false;
    }

    override public void UpdateVisuals()
    {
        for (int i = 0; i < 9; i++)
        {
            if (m_Data[i] != -1 && m_Pieces[i] == null)
            {
                m_Pieces[i] = Instantiate(m_Data[i] == 0 ? m_PiecePrefab_0 : m_PiecePrefab_1, transform);
                float posX = m_ThisCollider.bounds.min.x + ((i % 3) * 2 + 1) * m_ThisCollider.bounds.size.x / 6f;
                float posY = m_ThisCollider.bounds.min.y + ((i / 3) * 2 + 1) * m_ThisCollider.bounds.size.y / 6f;
                m_Pieces[i].transform.position = new Vector2(posX, posY);
            }
        }
    }

    private void AIMove()
    {
        int ActionAI = AI(m_Data);
        PlayerInput(ActionAI, 1);
        m_EnableInput = true;
    }
    private static int AI(int[] data)
    {
        for (int i = 0; i < 9; i++)
            if (data[i] == -1)
            {
                data[i] = 1;
                if (CheckWin(data, i))
                {
                    data[i] = -1;
                    return i;
                }
                data[i] = -1;
            }
        for (int i = 0; i < 9; i++)
            if (data[i] == -1)
            {
                data[i] = 0;
                if (CheckWin(data, i))
                {
                    data[i] = -1;
                    return i;
                }
                data[i] = -1;
            }
        int[] deck = new int[9];
        for (int i = 0; i < 9; i++) deck[i] = i;
        Utils.Shuffle(deck);
        for (int i = 0; i < 9; i++)
            if (data[deck[i]] == -1) return deck[i];
        return -1;
    }



    public void InitGame()
    {
        m_EnableInput = true;
        m_Running = true;
        m_Count = 0;
        for (int i = 0; i < 9; i++)
        {
            m_Data[i] = -1;
            if (m_Pieces[i])
            {
                Destroy(m_Pieces[i]);
                m_Pieces[i] = null;
            }
        }
    }
}
