using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PressAnywhere))]
public class GC_2_6 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questions = null;
    [SerializeField]
    private GameObject Ending = null;

    private PressAnywhere press = null;
    private int currentStep = 0;
    private void Awake()
    {
        press = GetComponent<PressAnywhere>();
    }

    private void OnEnable()
    {
        currentStep = 0;
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        Ending.SetActive(currentStep == questions.Length);
        for (int i = 0; i < questions.Length; i++)
            questions[i].SetActive(i <= currentStep);
    }

    private void NextQuestion()
    {
        if (currentStep < questions.Length)
        {
            currentStep++;
            UpdateVisuals();
        }
        else
        {
            press.Unlock();
            Ending.SetActive(true);
        }
    }
}
