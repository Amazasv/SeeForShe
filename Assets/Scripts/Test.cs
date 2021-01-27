using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Test : MonoBehaviour,ILayoutElement
{
    public RectOffset padding;

    public float minWidth => throw new System.NotImplementedException();

    public float preferredWidth => throw new System.NotImplementedException();

    public float flexibleWidth => throw new System.NotImplementedException();

    public float minHeight => throw new System.NotImplementedException();

    public float preferredHeight => throw new System.NotImplementedException();

    public float flexibleHeight => throw new System.NotImplementedException();

    public int layoutPriority => throw new System.NotImplementedException();

    public void CalculateLayoutInputHorizontal()
    {
        throw new System.NotImplementedException();
    }

    public void CalculateLayoutInputVertical()
    {
        throw new System.NotImplementedException();
    }

    //public HorizontalLayoutGroup group = null;
    private void f(int a)
    {

    }
    private void Start()
    {
        Debug.Log(padding.horizontal);
        Debug.Log(padding.vertical);
    }
}
