using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_ex1 : MonoBehaviour
{
    private string[] script = new string[16]
    {
"你好，我要求商场广播，提醒商场里的其他女性，你们这里有人性骚扰顾客。",
"小姐您好，您能具体讲讲发生了什么吗?",
"我在你们商场的四楼被人袭胸了。到现在都没有人来处理这个事情。",
"理解，我们这边确实之前也没遇到过这样的事情，您是在哪个位置遇到的啊？ ",
"就在四楼上电梯以后转角的地方，我看手机，没注意到迎面来了人。",
"哦...看手机啊，那你怎么知道他不是不小心碰到的啊？",
"一般人会碰到别人的胸吗！我就想知道，顾客遇到这种事情，商场不负责处理吗？你们只是负责商品的安全的吗",
"啊…这种情况啊，我们商场没有先例呢。",
"那，那我希望商场里能够播放广播，提醒其他一个人在这里逛街的女性。 ",
"抱歉女士，我们这边商场的广播也是有规定的，需要提前申请才可以审批，我这边也没有办法呢。",
"那监控呢？有人在商场里猥亵女性了， 把他的照片贴在商场门口提醒别人总是可以吧？",
"我们这边的监控也是需要审批才可以查看的，除非您这边报警，警察来调取，我们才会调取的。",
"只有报警商场才会处理吗？",
"嗯嗯，您这边的需求，我们的制度上没有提到过，我也是按规定办事。",
"....",
"那您这边要是没有别的事情了，我就先去忙了。"
    };


    [SerializeField]
    private Reversi game = null;
    [SerializeField]
    private TextEffect upText = null, downText = null;


    private int step;
    private void Awake()
    {
        game.OnInput.AddListener(OnInput);
        game.OnEnd.AddListener(OnGameEnd);
    }

    private void OnEnable()
    {
        step = 0;
    }

    private void OnInput(int side)
    {
        if (side == 0) downText.PutText(script[step++]);
        if (side == 1) upText.PutText(script[step++]);
    }
    private void OnGameEnd(int side)
    {

    }
}
