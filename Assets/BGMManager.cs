using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(LevelManager))]
public class BGMManager : MonoBehaviour
{
    [Serializable]
    private class BGMInfo
    {
        public AudioSource src = null;
        public int startIndex = 0;
        public int endIndex = 0;
    }
    [SerializeField]
    private List<BGMInfo> BGMList = new List<BGMInfo>();


    private LevelManager levelManager = null;

    private void Awake()
    {
        levelManager = GetComponent<LevelManager>();
        levelManager.OnSceneChange.AddListener(UpdateAudio);
    }

    public void UpdateAudio()
    {
        if (levelManager == null) levelManager = GetComponent<LevelManager>();
        foreach (BGMInfo BGM in BGMList)
        {
            if (levelManager.sceneIndex < BGM.startIndex || levelManager.sceneIndex > BGM.endIndex)
            {
                BGM.src.gameObject.SetActive(false);
            }
            else
            {
                BGM.src.gameObject.SetActive(true);
            }
        }
    }

}
