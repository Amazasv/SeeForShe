using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(JumpScene))]
public class GC_1_3 : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> portraits=new List<GameObject>();
    [SerializeField]
    private List<Draggable> items=new List<Draggable>();

    private int currentStep = 0;
    private JumpScene press = null;

    private void Awake()
    {
        press = GetComponent<JumpScene>();
    }

    private void OnEnable()
    {
        UpdateVisual();
    }

    public void DressUp()
    {
        currentStep++;
        UpdateVisual();
        if (currentStep == items.Count)
        {
            press.ForceTransition();
        }
    }

    public void DropCheck(Draggable item)
    {
        if (items.IndexOf(item) == currentStep)
        {
            DressUp();
        }
    }

    private void UpdateVisual()
    {
        for (int i = 0; i < items.Count; i++) items[i].gameObject.SetActive(i >= currentStep);
        foreach (GameObject tmp in portraits) tmp.SetActive(false);
        if (currentStep < portraits.Count)
            portraits[currentStep].SetActive(true);
    }
}
