using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_2_7 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questions = null;
    [SerializeField]
    private GameObject Ending = null;

    private int currentStep = -1;

    private void OnEnable()
    {
        currentStep = -1;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        Ending.SetActive(currentStep == questions.Length);
        for (int i = 0; i < questions.Length; i++)
            questions[i].SetActive(i <= currentStep);
    }

    public void NextQuestion()
    {
        if (currentStep < questions.Length)
        {
            currentStep++;
            UpdateVisuals();
        }
    }

}
