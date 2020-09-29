using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public int time = 15 * 60 + 30;
    public Dictionary<string, bool> globalFlags = new Dictionary<string, bool>()
    {
        {"catch",false },
        {"get_help",false },
        {"gentle_speaking",false }
    };
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
        globalFlags["catch"] = false;
        globalFlags["get_help"] = false;
        globalFlags["gentle_speaking"] = false;
    }
}
