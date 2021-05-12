using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talking : MonoBehaviour
{
    [SerializeField]
    private GameObject m_bubblePrefab = null;
    [SerializeField]
    private Transform m_parent = null;
    [SerializeField]
    private Vector2 m_offset = Vector2.zero;

    private readonly List<GameObject> m_bubbleList = new List<GameObject>();

    private void OnEnable()
    {
        ClearAll();
    }

    public void Speak(string content)
    {
        GameObject newBubble = Instantiate(m_bubblePrefab, m_parent);
        newBubble.transform.Translate(m_offset);
        Text text = newBubble.GetComponentInChildren<Text>();
        if (text) text.text = content;
        else Debug.LogWarning(newBubble.name + " has no Text Component");
        m_bubbleList.Add(newBubble);
    }

    public void ClearAll(float delay = 0.0f)
    {
        foreach (GameObject tmp in m_bubbleList) Destroy(tmp, delay);
        m_bubbleList.Clear();
    }
}
