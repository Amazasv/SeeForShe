using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 15 * 60 + 30;

    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SwitchChapter(int index)
    {
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
}
