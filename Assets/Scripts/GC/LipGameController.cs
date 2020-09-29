using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LipGameController : MonoBehaviour
{
    [SerializeField]
    private GameObject undoButton = null;
    [SerializeField]
    private GameObject[] lips = null;

    public UnityEvent OnVictory;


    private List<GameObject> pickList = new List<GameObject>();

    public void Choose(GameObject t)
    {
        pickList.Add(t);
        t.GetComponentInChildren<CanvasGroup>().alpha = 1;
        t.GetComponentInChildren<Text>().text = pickList.Count.ToString();
        t.GetComponent<Button>().interactable = false;
        undoButton.SetActive(true);
        undoButton.transform.position = t.transform.position;
        if (pickList.Count == lips.Length)
        {
            if (Check())
            {
                undoButton.gameObject.SetActive(false);
                OnVictory.Invoke();
            }
            else
            {
                while (pickList.Count > 0) Undo();
            }
        }
    }

    public void Undo()
    {
        if (pickList.Count > 0)
        {
            GameObject t = pickList[pickList.Count - 1];
            t.GetComponent<Button>().interactable = true;
            t.GetComponentInChildren<CanvasGroup>().alpha = 0;
            pickList.Remove(t);
            if (pickList.Count > 0)
            {
                undoButton.transform.position = pickList[pickList.Count - 1].transform.position;
            }
            else
            {
                undoButton.SetActive(false);
            }
        }
    }

    private bool Check()
    {
        for (int i = 0; i < pickList.Count; i++)
            if (pickList[i] != lips[i])
                return false;
        return true;
    }
}
