using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameDialog : MonoBehaviour
{
    [SerializeField]
    private Talking up = null;
    [SerializeField]
    private Talking down = null;
    [SerializeField]
    private MiniGame game = null;
    [SerializeField]
    private GameObject win = null, lose = null, draw = null;
    [SerializeField]
    private MoodController girlMood, npcMood;

    int count = 0;
    [SerializeField]
    private string[] script = null;
    private void Awake()
    {
        game.OnInput.AddListener(OnInput);
        game.OnEnd.AddListener(OnEnd);
    }

    private void OnEnable()
    {
        count = 0;
    }
    private void OnInput(int side)
    {
        if (count >= script.Length) return;
        if (side == 0)
        {
            down.Speak(script[count++]);
            down.ClearAll(2f);
        }
        if (side == 1)
        {
            up.Speak(script[count++]);
            up.ClearAll(2f);
        }
    }

    private void OnEnd(int side)
    {
        StartCoroutine(ShowEnding(side));
    }

    IEnumerator ShowEnding(int side)
    {
        yield return new WaitForSeconds(2.0f);
        up.gameObject.SetActive(false);
        down.gameObject.SetActive(false);
        switch (side)
        {
            case -1: draw.SetActive(true); break;
            case 1: lose.SetActive(true); break;
            case 0: win.SetActive(true); break;
        }
    }
}
