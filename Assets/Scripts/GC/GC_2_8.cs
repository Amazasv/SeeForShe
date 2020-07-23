using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpScene))]
public class GC_2_8 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questions = null;
    [SerializeField]
    private GameObject Ending = null;

    private JumpScene press = null;
    private int currentStep = 0;
    private void Awake()
    {
        press = GetComponent<JumpScene>();
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

    public void NextQuestion()
    {
        if (currentStep < questions.Length)
        {
            currentStep++;
            UpdateVisuals();
            if (currentStep == questions.Length)
            {
                press.Unlock();
                Ending.SetActive(true);
            }
        }
    }
}
