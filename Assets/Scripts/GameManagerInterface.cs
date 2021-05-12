using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManagerInterface : MonoBehaviour
{
    public void SwitchChapter(int index)
    {
        GameManager.SwitchChapter(index);
    }

    public void SetFlag(string flag)
    {
        GameManager.Instance.flags[flag] = true;
    }

    public void SetTime(int value)
    {
        GameManager.SetTime(value);
    }

    public void AddRecord(string value)
    {
        GameManager.AddRecord(value);
    }

    public void SetAchievement(string achi)
    {
        GameManager.SetAchievement(achi);
    }

    public void AddTime(int value)
    {
        GameManager.AddTime(value);
    }

}
