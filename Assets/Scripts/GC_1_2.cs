using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


[RequireComponent(typeof(PressAnywhere))]
public class GC_1_2 : MonoBehaviour
{
    public PlayableDirector[] directors;

    private PressAnywhere press;
    private int currentStep = 0;

    private void Awake()
    {
        press = GetComponent<PressAnywhere>();
    }

    private void OnEnable()
    {
        currentStep = 0;
        NextCut();
    }

    public void NextCut()
    {
        if (currentStep < directors.Length)
        {
            DisableAllCut();
            directors[currentStep++].gameObject.SetActive(true);
        }
        else
        {
            press.Unlock();
        }
    }

    private void DisableAllCut()
    {
        foreach (PlayableDirector tmp in directors) tmp.gameObject.SetActive(false);
    }


}
