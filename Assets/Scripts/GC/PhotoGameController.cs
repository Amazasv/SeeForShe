using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class PhotoGameController : GCSequence
{
    [SerializeField]
    private Animation lipTransition = null;
    [SerializeField]
    private Sprite[] photos = null;

    private CameraManager cameraManager = null;
    private MyCamera myCamera = null;
    private void Awake()
    {
        myCamera = GetComponentInChildren<MyCamera>();
        cameraManager = GetComponentInChildren<CameraManager>(true);

    }

    private void Start()
    {
        CurrentStep = 0;
        lipTransition.gameObject.SetActive(false);
    }

    public void Cheese()
    {
        GameObject newPhoto = myCamera.Print();
        cameraManager.gameObject.SetActive(true);
        cameraManager.Print(newPhoto);
        CurrentStep++;
        if (CurrentStep < 3)
        {
            myCamera.SetImage(photos[CurrentStep]);
        }
        else if (CurrentStep == 3)
        {
            myCamera.gameObject.SetActive(false);
            
            lipTransition.gameObject.SetActive(true);
            cameraManager.director.stopped += Director_stopped;
        }
        
    }

    private void Director_stopped(PlayableDirector obj)
    {
        lipTransition.Play();
        myCamera.transform.parent.gameObject.SetActive(false);
    }
}
