using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    [SerializeField]
    private Vector2Int m_time;
    public int time
    {
        get { return m_time.x * 60 + m_time.y; }
        set { m_time = new Vector2Int(value / 60, value % 60); }
    }


    [SerializeField]
    private StringBoolDictionary m_flags = new StringBoolDictionary();
    public IDictionary<string, bool> flags
    {
        get { return m_flags; }
        set { m_flags.CopyFrom(value); }
    }

    public HashSet<string> progressRec { get; private set; } = new HashSet<string>();

    [SerializeField]
    private StringBoolDictionary m_Achievement = new StringBoolDictionary();
    public IDictionary<string, bool> achievement
    {
        get { return m_Achievement; }
        set { m_Achievement.CopyFrom(value); }
    }

    private void Awake()
    {
        if (Instance) Destroy(gameObject);
        else
        {
            Instance = this;
            Init();
            DontDestroyOnLoad(gameObject);
            achievement = new Dictionary<string, bool>()
            {
                {"pass_c0",false },
                {"pass_c1",false },
                {"pass_c2",false },
                {"pass_c3",false },
                {"pass_c4",false },
                {"pass_c5",false },
                {"pass_c6",false },
                {"pass_c7",false },
                {"pass_c8",false }
            };
        }
    }

    public static void SwitchChapter(int index)
    {
        if (index == 0) Instance.Init();
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
        m_time = new Vector2Int(15, 30);
        flags = new Dictionary<string, bool>()
        {
            {"catch",false },
            {"get_help",false },
            {"gentle_speaking",false }
        };

        progressRec = new HashSet<string>();
    }

    public PlayerData GetPlayerData()
    {
        PlayerData data = new PlayerData();
        data.time = time;
        data.chapter = SceneManager.GetActiveScene().buildIndex;
        List<string> tmp = new List<string>();
        foreach (KeyValuePair<string, bool> kvp in flags)
        {
            if (kvp.Value) tmp.Add(kvp.Key);
        }
        data.flags = tmp.ToArray();
        data.recs = progressRec.ToArray();
        return data;
    }

    public void LoadPlayerData(PlayerData data)
    {
        Init();
        time = data.time;
        foreach (string s in data.flags)
        {
            flags[s] = true;
        }
        foreach (string s in data.recs)
        {
            progressRec.Add(s);
        }
        SceneManager.LoadScene(data.chapter);
    }

    public static void AddRecord(string value)
    {
        Instance.progressRec.Add("TIME=" + Instance.time + ";" + "DESC=" + value + ";");
    }

    public static void SetAchievement(string achi)
    {
        SaveSystem.SaveData(achi);
        Instance.achievement[achi] = true;
    }

    public static void AddTime(int value)
    {
        Instance.time += value;
    }
    public static void SetTime(int value)
    {
        Instance.time = value;
    }
}
