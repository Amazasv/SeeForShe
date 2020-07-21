using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    static private int initialTime = 8 * 60;
    static private int time = 0;
    static public string DisplayTime()
    {
        int finalTime = initialTime + time;
        string res = "";
        res = (finalTime / 600).ToString() + (finalTime / 60 % 10).ToString() + (finalTime / 10 % 10).ToString() + (finalTime % 10).ToString();
        return res;
    }
    static public void AddTime(int value)
    {
        time += value;
    }
}
