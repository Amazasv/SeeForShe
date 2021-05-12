using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerInterface : MonoBehaviour
{
    public void SetLevel(ObjectLevel next)
    {
        LevelManager.instance.SetLevel(next);
    }

    public void SetChapter(int index)
    {
        LevelManager.instance.SetChapter(index);
    }
}
