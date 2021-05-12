using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MatchDialog: MonoBehaviour
{
    public UnityEvent OnStop = new UnityEvent();


    private readonly string[] introduction = new string[2]{
"讲一下吧，什么情况？     ",
"我...我在商场被人袭胸了。"
        };
    private readonly string[] rightScript = new string[14]
    {
"在商场哪个位置啊？",
"就在四楼上电梯以后的转角，靠近一个施工的店铺。",

"他怎么摸到你的？",
"我当时在看手机，没注意到对面有人来了，擦肩而过的时候他突然抬起手...",

"他摸完你以后呢？",
"我..我有点儿害怕，他们有两个人，我一时间被吓到了没太注意。",

"你怎么知道他摸的你？",
"因为我很疼啊！他是用力抓了一下，我当然有感觉。",

"他用哪只手摸的，你还记得吗？",
"是左手，因为他是迎面过来的，我右手拿着手机。",

"他摸完你就直接跑了？",
"是的，我回过神之后有尝试去追，但是还是让他跑了。",

"这种行为还是太危险了，如果他身上有什么利器的话，是会影响你的生命安全的。",
"抱歉我当时太激动了，回过神来才发觉这是一个很危险的举动。"
    };
    private readonly int[] rightMood = new int[14]
    {
        0,0,
        0,0,
        0,0,
        0,1,
        0,0,
        0,1,
        2,0
    };

    private readonly string[] wrongScript = new string[8]
    {
"在商场哪个位置啊？",
"我记得是四楼还是五楼上电梯以后的转角，我是第一次来这个商场，具体的位置记不太清楚了。",

"他怎么摸到你的？",
"我在看手机没太注意。",

"他用哪只手摸的，你还记得吗？",
"我不太记得了，当时太慌张了。",

"他穿什么颜色的衣服你还记得吗？",
"我记不起来了...当时太紧张了，我有一点儿害怕…"
    };

    private readonly int[] wrongMood = new int[8]
    {
        0,0,
        0,0,
        1,0,
        0,0
    };

    private readonly string[] repeatScript = new string[8]
    {
"你想怎么办？",
"我也不知道该怎么办才到警察局求助的。",

"你还记得其他的细节吗？",
"我想想看...",

"你还记得其他的细节吗？",
"记不清楚了，记忆有点混乱。",

"你有什么想补充的吗？",
"没有了，我想不起来其他更有用的信息了。"
    };

    private readonly int[] repeatMood = new int[8]
    {
        0,0,
        0,0,
        0,1,
        0,1
    };


    private readonly string[] heScript = new string[2]
    {
"你提供的信息非常有帮助，如果顺利的话， 我们应该可以很快锁定他，最后想再问一下，他穿什么颜色的衣服你还记得吗？",
"我得想想看..."
    };

    private readonly string[] beScript = new string[2]
{

"感谢你的配合，不过信息确实有一些少，锁定他的难度比较高，我们等会儿要去监控室再试试，最后想再问一下，他穿什么颜色的衣服你还记得吗？",
"我得想想看..."
    };


    [SerializeField]
    private MiniGame game = null;
    [SerializeField]
    private GameObject girl = null, police = null;
    [SerializeField]
    private float gap = 2.0f;

    private Talking girlTalkScript, policeTalkScript;
    private MoodController girlMood, policeMood;

    private int rightCnt = 0;
    private int wrongCnt = 0;


    private void Awake()
    {

        UpdateREF();
        game.OnInput.AddListener(OnInput);
        game.OnEnd.AddListener(OnEnd);
    }

    private void OnEnable()
    {
        game.running = false;
        //girlMood.mood = policeMood.mood = 0;
        StartCoroutine(Print2Line(introduction[0], introduction[1], true));

    }
    
    private void UpdateREF()
    {
        girlTalkScript = girl.GetComponent<Talking>();
        policeTalkScript = police.GetComponent<Talking>();
        girlMood = girl.GetComponent<MoodController>();
        policeMood = girl.GetComponent<MoodController>();
    }


    private void OnInput(int type)
    {
        if (type == 0)
        {
            int i = 2 * rightCnt;
            if (i >= rightScript.Length) return;
            policeMood.mood = rightMood[i];
            girlMood.mood = rightMood[i + 1];
            StartCoroutine(Print2Line(rightScript[i], rightScript[i + 1], true));
            rightCnt++;
        }
        else
        {
            int i = 2 * wrongCnt;
            if (i >= wrongScript.Length)
            {
                i = 2 * Random.Range(0, repeatScript.Length / 2);
                policeMood.mood = repeatMood[i];
                girlMood.mood = repeatMood[i + 1];
                StartCoroutine(Print2Line(repeatScript[i], repeatScript[i + 1], true));
            }
            else
            {
                policeMood.mood = wrongMood[i];
                girlMood.mood = wrongMood[i + 1];
                StartCoroutine(Print2Line(wrongScript[i], wrongScript[i + 1], true));
            }
            wrongCnt++;
        }
    }

    private void OnEnd(int ending)
    {
        girlMood.mood = policeMood.mood = 0;
        if (ending > 0)
        {
            StartCoroutine(Print2Line(beScript[0], beScript[1], false));
        }
        else
        {
            StartCoroutine(Print2Line(heScript[0], heScript[1], false));
        }
    }

    IEnumerator Print2Line(string s1, string s2, bool resumeGame = true)
    {
        policeTalkScript.Speak(s1);
        policeMood.talk = true;
        yield return new WaitForSeconds(gap);
        policeTalkScript.ClearAll();
        policeMood.talk = false;
        girlMood.talk = true;
        girlTalkScript.Speak(s2);
        yield return new WaitForSeconds(gap);
        girlTalkScript.ClearAll();
        girlMood.talk = false;
        if (resumeGame) game.running = true;
        else OnStop.Invoke();
    }
}
