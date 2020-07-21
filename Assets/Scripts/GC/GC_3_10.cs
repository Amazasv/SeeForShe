using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_3_10 : MonoBehaviour
{
    public bool head = false;
    public bool paints = false;
    public bool clothes = false;
    [SerializeField]
    private GameObject[] tabs = new GameObject[3];
    [SerializeField]
    private GameObject[] headPortraits = new GameObject[3];
    [SerializeField]
    private GameObject[] clothesPortraits = new GameObject[3];
    [SerializeField]
    private GameObject[] paintPortraits = new GameObject[3];

    private int currentTab = 0;
    private int[] currentSelected = new int[3];
    private void OnEnable()
    {
        SelectTab(0);
        for (int i = 0; i < 3; i++) currentSelected[i] = -1;
        UpdateVisuals();
    }

    public void SelectTab(int index)
    {
        currentTab = index;
        tabs[currentTab].transform.SetAsLastSibling();
    }

    public void SelectItem(int index)
    {
        currentSelected[currentTab] = index;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        for (int i = 0; i < 3; i++)
        {
            headPortraits[i].SetActive(currentSelected[0] == i);
            clothesPortraits[i].SetActive(currentSelected[1] == i);
            paintPortraits[i].SetActive(currentSelected[2] == i);
        }
    }



    public void Check()
    {

    }
}
