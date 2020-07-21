using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_2_1 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects = null;

    [SerializeField]
    private float[] gap = null;

    private int currentStep = 0;

    private void OnEnable()
    {
        CancelInvoke();
        currentStep = 0;
        UpdateVisuals();
        Invoke("TimeLine", gap[0]);
    }

    public void TimeLine()
    {
        currentStep++;
        UpdateVisuals();
        if (currentStep < gap.Length)
            Invoke("TimeLine", gap[currentStep]);
    }


    private void UpdateVisuals()
    {
        for (int i = 0; i < gameObjects.Length; i++)
            if (i < currentStep) gameObjects[i].SetActive(true);
            else gameObjects[i].SetActive(false);
    }

}
