
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static PlayerData Preset_Chap1;
    public static PlayerData Preset_Chap2;
    public static PlayerData Preset_Chap3;
    public static PlayerData Preset_Chap4;


    public static void SaveData(string filename)
    {
        Debug.Log("save");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + filename + ".sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = GameManager.Instance.GetPlayerData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static bool IsDataExist(string filename)
    {
        string path = Application.persistentDataPath + "/" + filename + ".sav";
        return File.Exists(path);
    }

    public static void LoadData(string filename)
    {
        Debug.Log("load");
        string path = Application.persistentDataPath + "/" + filename + ".sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            GameManager.Instance.LoadPlayerData(data);
            stream.Close();
        }
        else
        {
            Debug.LogError("Save File not found in " + path);
        }
    }
}
