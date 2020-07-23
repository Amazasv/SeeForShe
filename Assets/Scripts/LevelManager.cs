using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField]
    private int startScene = 0;


    [SerializeField]
    private LevelBase[] levelBases = null;

    private int sceneIndex;
    private int nextScene;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        nextScene = sceneIndex = startScene;
        UpdateScene();
    }

    public void StartTransition(int next)
    {
        if (next < levelBases.Length)
        {
            nextScene = next;
            levelBases[sceneIndex].OutTransition();
        }
        else
        {
            StartNextChapter();
        }

    }
    public void StartNextChapter()
    {
        
        levelBases[sceneIndex].OutTransition();
        levelBases[sceneIndex].outDirector.stopped += delegate { GameManager.Instance.NextChapter(); };
    }


    public void StartSwitchChapter(int next)
    {
        levelBases[sceneIndex].OutTransition();
        levelBases[sceneIndex].outDirector.stopped += delegate { GameManager.Instance.SwitchChapter(next); };
    }

    public void UpdateScene()
    {
        sceneIndex = nextScene;
        foreach (LevelBase tmp in levelBases) tmp.gameObject.SetActive(false);
        levelBases[sceneIndex].gameObject.SetActive(true);
        levelBases[sceneIndex].InTransition();
    }
}
