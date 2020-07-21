using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LipGameController : MonoBehaviour
{
    [SerializeField]
    private Transform undoButton = null;
    [SerializeField]
    private Transform lips = null;
    [SerializeField]
    private int[] order = new int[6];


    public List<Transform> indices;

    public void Choose(Transform trans)
    {
        indices.Add(trans);
        Text text = trans.GetComponentInChildren<Text>();
        if (text)
        {
            Color color = text.color;
            color.a = 1;
            text.color = color;
            text.text = indices.Count.ToString();
        }
        undoButton.gameObject.SetActive(true);
        undoButton.position = trans.position;
        if (indices.Count == lips.childCount) Check();
    }

    private bool undo()
    {
        if (indices.Count > 0)
        {
            indices[indices.Count - 1].GetComponent<Button>().interactable = true;
            Text text = indices[indices.Count - 1].GetComponentInChildren<Text>();
            if (text)
            {
                Color color = text.color;
                color.a = 0;
                text.color = color;
            }
            indices.RemoveAt(indices.Count - 1);
            if (indices.Count > 0) undoButton.position = indices[indices.Count - 1].position;
            else undoButton.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    public void UndoButton()
    {
        undo();
    }
    private bool Check()
    {
        for (int i = 0; i < indices.Count; i++)
            if (indices[i].GetSiblingIndex() != order[i])
            {
                while (undo()) ;
                return false;
            }
        undoButton.gameObject.SetActive(false);
      //  GameManager.Transilate2Level(5);
        return true;
    }
}
