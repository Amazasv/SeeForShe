using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDisplayClue : MonoBehaviour
{
    [SerializeField]
    private int clueIndex = 0;
    private void Awake()
    {
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        gameObject.SetActive(GC_5.clueCollected[clueIndex]);
    }
}
