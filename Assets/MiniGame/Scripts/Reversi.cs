using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reversi : MiniGame
{
    [SerializeField]
    private GameObject m_CardPrefab_0 = null;
    [SerializeField]
    private Vector2 m_CellSize = Vector2.one;
    [SerializeField]
    private Vector2 m_Spacing = Vector2.one;

    private readonly GameObject[] m_Pieces = new GameObject[16];
    private readonly int[] m_Data = new int[16];
    private bool m_PlayerTurn = false;
    private bool m_Running = false;
    private int[] m_Count;
    private void Start()
    {
        InitGame();
    }

    private void OnMouseUpAsButton()
    {
        if (!m_PlayerTurn || !m_Running)
        {
            Debug.Log("现在不能放置棋子");
            return;
        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 totalSize = 4 * m_CellSize + 3 * m_Spacing;
        Vector2 minPos = mousePos + 0.5f * totalSize;
        int indexX = -1;
        int indexY = -1;
        for (int i = 0; i < 4; i++)
        {
            if (minPos.x > 0 && minPos.x < m_CellSize.x) indexX = i;
            if (minPos.y > 0 && minPos.y < m_CellSize.y) indexY = i;
            minPos -= m_CellSize;
            minPos -= m_Spacing;
        }
        if (indexX >= 0 && indexY >= 0 && PlayerInput(indexX + 4 * indexY, 0))
        {
            m_PlayerTurn = false;
            if (m_Running)
                Invoke(nameof(AIMove), AIdelay);
        }
    }

    public bool PlayerInput(int index, int side)
    {
        if (index < 0 || index >= 16)
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
        UpdateCards(m_Data, index, true);
        m_Count[side]++;
        UpdateVisuals();
        Debug.Log(side.ToString() + "类棋子放置于第" + index.ToString() + "号格子");
        OnInput.Invoke(side);
        if (m_Count[0] + m_Count[1] == 16)
        {
            Debug.Log("结束");
            if (m_Count[0] > m_Count[1]) OnEnd.Invoke(0);
            else if (m_Count[0] < m_Count[1]) OnEnd.Invoke(1);
            else OnEnd.Invoke(-1);
            m_Running = false;
        }
        return true;
    }

    private readonly static int[] dx = { 0, 0, -1, -1, -1, 1, 1, 1 };
    private readonly static int[] dy = { 1, -1, -1, 0, 1, -1, 0, 1 };
    private static int UpdateCards(int[] data, int index, bool really)
    {
        int x = index % 4;
        int y = index / 4;
        int cnt = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int k = 1; k < 4; k++)
            {
                int px = x + k * dx[i];
                int py = y + k * dy[i];
                if (px < 0 || px >= 4 || py < 0 || py >= 4) break;
                if (data[py * 4 + px] == -1) break;
                else if (data[py * 4 + px] == data[index])
                {
                    cnt += k - 1;
                    if (really)
                        for (int j = 1; j < k; j++) data[4 * (y + j * dy[i]) + (x + j * dx[i])] = data[index];
                }
            }
        }
        return cnt;
    }

    private void AIMove()
    {
        int ActionAI = AI(m_Data, 1);
        PlayerInput(ActionAI, 1);
        m_PlayerTurn = true;
    }

    private static int AI(int[] data, int val)
    {
        int maxm = 0;
        int rec = -1;
        for (int i = 0; i < 16; i++)
        {
            if (data[i] != -1) continue;
            data[i] = val;
            int score = UpdateCards(data, i, false);
            data[i] = -1;
            if (score > maxm)
            {
                maxm = score;
                rec = i;
            }
        }
        return rec;
    }

    override public void UpdateVisuals()
    {
        for (int i = 0; i < 16; i++)
        {
            m_Pieces[i].SetActive(m_Data[i] != -1);
            m_Pieces[i].GetComponent<Animator>().SetBool("Flip", m_Data[i] == 1);
        }
    }

    private void InitGame()
    {
        m_PlayerTurn = true;
        m_Running = true;
        m_Count = new int[2];
        Vector2 totalSize = 4 * m_CellSize + 3 * m_Spacing;
        for (int i = 0; i < 16; i++)
        {
            int row = i / 4;
            int col = i % 4;
            m_Pieces[i] = Instantiate(m_CardPrefab_0, transform);
            m_Pieces[i].SetActive(false);
            float PosX = ((0.5f * m_CellSize + col * m_CellSize + col * m_Spacing) - 0.5f * totalSize).x;
            float PosY = ((0.5f * m_CellSize + row * m_CellSize + row * m_Spacing) - 0.5f * totalSize).y;
            m_Pieces[i].transform.position = transform.position + new Vector3(PosX, PosY, 0f);
            m_Data[i] = -1;
        }
        m_Data[5] = m_Data[10] = 0;
        m_Data[6] = m_Data[9] = 1;
        m_Count[0] = m_Count[1] = 2;
        UpdateVisuals();
    }
}
