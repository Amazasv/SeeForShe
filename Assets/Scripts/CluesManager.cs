using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CluesManager : MonoBehaviour
{
    


    private void OnEnable()
    {
        UpdateVisuals();
    }
    private void UpdateVisuals()
    {
        transform.GetChild(0).gameObject.SetActive(GC_5.clueCollected[0]);
        transform.GetChild(1).gameObject.SetActive(GC_5.clueCollected[1]);
        transform.GetChild(2).gameObject.SetActive(GC_5.clueCollected[2]);
        transform.GetChild(3).gameObject.SetActive(GC_5.clueCollected[3]);
        transform.GetChild(4).gameObject.SetActive(GC_5.clueCollected[4]);
    }
}
