using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemInterface:MonoBehaviour
{
    private static readonly string defaultFileName = "player";
    public void Save()
    {
        SaveSystem.SaveData(defaultFileName);
    }

    public void Save(string name)
    {
        SaveSystem.SaveData(name);
    }

    public void Load()
    {
        SaveSystem.LoadData(defaultFileName);
    }

    public void Load(string name)
    {
        SaveSystem.LoadData(name);
    }
}
