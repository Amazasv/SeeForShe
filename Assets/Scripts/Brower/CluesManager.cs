using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clues = null;
    private void OnEnable()
    {
        UpdateVisuals();
    }
    private void UpdateVisuals()
    {
        for (int i = 0; i < clues.Length; i++)
        {
            clues[i].SetActive(GC_5.Instance.GetFlag(i));
        }
    }
}
