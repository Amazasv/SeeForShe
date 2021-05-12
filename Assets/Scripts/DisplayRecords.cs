using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public class DisplayRecords : MonoBehaviour
{
    private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>{
    {"trycatch","你抓住了施害者的衣角，依稀间看到他的外套里面穿了一件绿色T恤                         "} ,
    {"askhelp","你大喊求助，但是今天是工作日，商场内人很少，并没有人注意到你                         "} ,
    {"askmom","你找了妈妈但是没有人给你很好的建议                                                    "} ,
    {"askA","你找了小A但是没有人给你很好的建议                                                       "} ,
    {"askB","你找了小B但是没有人给你很好的建议                                                       "} ,
    {"zhihu","你查看了喵呼，（很好地/较好的/一般的/普通的）完成了相关的问题的选择，并觉得略有不甘        "} ,
    {"officer_win","你很快的说服了前台，不等多时经理便来向你了解具体情况了                                "} ,
    {"officer_lose","你别扭的向前台说明了遭遇，前台表示经理工作上有其他问题不能及时前来                    "} ,
    {"manager_win","你顺利的从经理了解到解决相关问题的途径，经理建议你联系警察进行下一步的调查            "} ,
    {"manager_lose","你向经理陈述相关诉求的过程并不是很顺利，无奈之下只能转向找警察求助                    "} ,
    {"police","你很清晰的回忆其相关细节并向警察做了合理陈述                                          "} ,
    {"10","你耻于表达相关的性骚扰情况，而且当时情况的发生的很突然不能很好的回忆起相关细节       "} ,
    {"recall_yes","你很好的回忆起了施害者的相关穿着                                                     "} ,
    {"recall_no","你受到的冲击太大不能很好的回忆起施害者的相关穿着                                     "} ,
    {"gomonitor","警察收集到了初步实事，并和你一起前往监控室进行下一步的证据收集                       "} ,
    {"convince_no","你与阿姨争执，在警察的介入后，才调取了相应的监控证据                                 "} ,
    {"convince_yes","你用道理说服了阿姨，并很快的调取了相应的监控证据                                     "}
    };

    [SerializeField]
    private GameObject recordPrefab = null;

    private List<GameObject> entries = new List<GameObject>();
    void UpdateVisuals()
    {
        foreach (string s in GameManager.Instance.progressRec)
        {
            GameObject entry=Instantiate(recordPrefab, transform);
            entries.Add(entry);
            ObjectRecordEntry entryObject = entry.GetComponent<ObjectRecordEntry>();

            Regex reg1 = new Regex("TIME=(.+?);");
            Match match1 = reg1.Match(s);
            entryObject.timeText.text = ToTimeFormat(int.Parse(match1.Groups[1].Value));

            Regex reg2 = new Regex("DESC=(.+?);");
            Match match2 = reg2.Match(s);
            if (dictionary.ContainsKey(match2.Groups[1].Value))
            {
                entryObject.descText.text = dictionary[match2.Groups[1].Value];
            }
            else
            {
                entryObject.descText.text = match2.Groups[1].Value;
            }
        }
    }

    public static string ToTimeFormat(int value)
    {
        return (value / 600).ToString() + (value / 60 % 10).ToString() + ":" + (value / 10 % 6).ToString() + (value % 10).ToString();
    }

    private void ClearAll()
    {
        foreach(GameObject o in entries)
        {
            Destroy(o);
        }
        entries.Clear();
    }

    private void OnEnable()
    {
        ClearAll();
        UpdateVisuals();
    }

}
