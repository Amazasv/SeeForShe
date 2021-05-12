using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchGame : MiniGame
{
    [SerializeField]
    private Vector2 m_CellSize = Vector2.one;
    [SerializeField]
    private Vector2 m_Spacing = Vector2.one;
    [SerializeField]
    private GameObject[] m_CardPrefabs = null;
    [SerializeField]
    private GameObject m_PauseObject = null;

    private const int rows = 2;
    private const int cols = 4;
    private const int pairs = 4;

    private readonly GameObject[] m_Pieces = new GameObject[rows * cols];
    private readonly int[] m_Data = new int[rows * cols];
    private readonly bool[] m_VisualState = new bool[rows * cols];
    private Vector2 totalSize;

    private int m_Count = 0;
    private int m_tries = 0;
    private int m_Record = -1;

    private void OnEnable()
    {
        InitGame();
        UpdateVisuals();
    }
    private void OnMouseUpAsButton()
    {
        if (!running)
        {
            Debug.Log("现在不能放置棋子");
            return;
        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 minPos = mousePos + 0.5f * totalSize;
        int x = -1;
        int y = -1;
        for (int i = 0; i < Mathf.Max(rows, cols); i++)
        {
            if (minPos.x > 0 && minPos.x < m_CellSize.x) x = i;
            if (minPos.y > 0 && minPos.y < m_CellSize.y) y = i;
            minPos -= m_CellSize;
            minPos -= m_Spacing;
        }
        if (x >= 0 && y >= 0)
            PlayerInput(cols * y + x);
    }

    public void PlayerInput(int index)
    {
        if (m_VisualState[index])
        {
            Debug.Log("已经翻开");
            return;
        }
        if (m_Record == -1)
        {
            m_Record = index;
            m_VisualState[m_Record] = true;
            UpdateVisuals();
        }
        else
        {
            m_tries++;
            if (m_tries >= 8)
            {
                for (int i = 0; i < m_VisualState.Length; i++)
                    m_VisualState[i] = true;
                UpdateVisuals();
                OnEnd.Invoke(1);
                running = false;
                return;
            }
            running = false;
            if (m_Data[m_Record] == m_Data[index] && m_Data[index] != -1)
            {
                OnInput.Invoke(0);
                m_VisualState[m_Record] = m_VisualState[index] = true;
                UpdateVisuals();
                m_Count += 2;
                if (m_Count == 2 * pairs)
                {
                    Debug.Log("结束");
                    OnEnd.Invoke(0);
                    running = false;
                }
            }
            else
            {
                OnInput.Invoke(1);
                m_VisualState[m_Record] = m_VisualState[index] = true;
                UpdateVisuals();
                m_VisualState[m_Record] = m_VisualState[index] = false;
                Invoke(nameof(UpdateVisuals), 1.0f);
            }
            m_Record = -1;
        }

    }

    override public void UpdateVisuals()
    {
        if (m_PauseObject) m_PauseObject.SetActive(!running);
        for (int i = 0; i < m_Pieces.Length; i++)
        {
            if (m_Pieces[i])
                m_Pieces[i].GetComponent<Animator>().SetBool("Visable", m_VisualState[i]);
        }
    }

    private void InitGame()
    {
        m_Count = 0;
        totalSize = new Vector2(cols, rows) * (m_CellSize + m_Spacing) - m_Spacing;
        foreach (GameObject o in m_Pieces)
            Destroy(o);
        for (int i = 0; i < m_Data.Length; i++) m_Data[i] = -1;
        for (int i = 0; i < pairs && i < m_CardPrefabs.Length; i++)
            m_Data[2 * i] = m_Data[2 * i + 1] = i;
        Utils.Shuffle(m_Data);
        for (int i = 0; i < m_Data.Length; i++)
        {
            m_VisualState[i] = false;
            int row = i / cols;
            int col = i % cols;
            m_Pieces[i] = Instantiate(m_CardPrefabs[m_Data[i]], transform);
            float PosX = ((0.5f * m_CellSize + col * m_CellSize + col * m_Spacing) - 0.5f * totalSize).x;
            float PosY = ((0.5f * m_CellSize + row * m_CellSize + row * m_Spacing) - 0.5f * totalSize).y;
            m_Pieces[i].transform.position = transform.position + new Vector3(PosX, PosY, 0f);
        }
    }
}
