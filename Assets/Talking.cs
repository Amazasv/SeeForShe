using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talking : MonoBehaviour
{
    [SerializeField]
    private GameObject bubblePrefab = null;
    [SerializeField]
    private Transform parent = null;

    private List<GameObject> bubbleList = new List<GameObject>();

    private void OnEnable()
    {
        ForceClear();
    }

    public void Speak(string content)
    {
        GameObject newBubble = Instantiate(bubblePrefab, parent);
        newBubble.GetComponentInChildren<Text>().text = content;
        bubbleList.Add(newBubble);
    }

    public void ForceClear(float delay = 0.0f)
    {
        foreach (GameObject tmp in bubbleList) Destroy(tmp, delay);
        bubbleList.Clear();
    }

}
