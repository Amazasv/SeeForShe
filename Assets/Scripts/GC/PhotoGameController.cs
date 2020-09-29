using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class PhotoGameController : MonoBehaviour
{
    [SerializeField]
    private int currentStep = 0;
    [SerializeField]
    private int timelineStep = 0;
    private PlayableDirector playableDirector;
    [SerializeField]
    private List<Button> buttons=new List<Button>();
    private void Awake()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        playableDirector.Play();
        currentStep = 0;
        timelineStep = 0;
        UpdateVisuals();
    }

    public void CheckPause()
    {
        if (timelineStep >= currentStep) playableDirector.Pause();
        timelineStep++;
    }

    public void Choose(int index)
    {
        if (index == currentStep)
        {
            playableDirector.Resume();
            currentStep++;
            UpdateVisuals();
        }
    }

    private void UpdateVisuals()
    {
        for (int i = 0; i < buttons.Count; i++) buttons[i].interactable = (i >= currentStep);
    }

}
