using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public int time = 15 * 60 + 30;
    public bool flag_catch = false;
    public bool flag_get_help = false;
    public bool flag_gentle_speaking = false;
    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SwitchChapter(int index)
    {
        if (index == 0) Init();
        SceneManager.LoadScene(index);
    }

    public void NextChapter()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SwitchChapter(index + 1);
        }
    }

    private void Init()
    {
        time = 15 * 60 + 30;
        flag_catch = false;
        flag_get_help = false;
        flag_gentle_speaking = false;
    }
}
