using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class LevelBase : MonoBehaviour
{
    public PlayableDirector inDirector;
    public PlayableDirector outDirector;

    private void Start()
    {
        //inDirector.stopped += OnPlayableStopped;
        //outDirector.stopped += OnPlayableStopped;
        outDirector.stopped += delegate { LevelManager.Instance.UpdateScene(); };
    }

    public void InTransition()
    {
        //LevelManager.Instance.EventSystem.SetActive(false);
        inDirector.Play();
    }

    public void OutTransition()
    {
       // LevelManager.Instance.EventSystem.SetActive(false);
        outDirector.Play();
    }

    //private void OnPlayableStopped(PlayableDirector aDirector)
    //{
    //  //  if (LevelManager.Instance)
    //    //    LevelManager.Instance.EventSystem.SetActive(true);
    //}
}
