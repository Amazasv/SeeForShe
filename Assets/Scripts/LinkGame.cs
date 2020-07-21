using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkGame : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tutorials = null;
    [SerializeField]
    private GameObject[] easys = null;
    [SerializeField]
    private GameObject[] normals = null;
    [SerializeField]
    private GameObject[] hards = null;

    public static GameObject[] tutorialGames = null;
    public static GameObject[] easyGames = null;
    public static GameObject[] normalGames = null;
    public static GameObject[] hardGames = null;

    private static  int tutorialsCnt = 0;
    private static  int easysCnt = 0;
    private static int normalsCnt = 0;
    private static int hardsCnt = 0;

    private void Awake()
    {
        tutorialGames = tutorials;
        easyGames = easys;
        normalGames = normals;
        hardGames = hards;
    }

    public static GameObject GetGame(int difficulty)
    {
        switch (difficulty)
        {
            case 0:
                if (tutorialsCnt < tutorialGames.Length) return tutorialGames[tutorialsCnt++];
                else return GetGame(difficulty + 1);
            case 1:
                if (easysCnt < easyGames.Length) return easyGames[easysCnt++];
                else return GetGame(difficulty + 1);
            case 2:
                if (normalsCnt < normalGames.Length) return normalGames[normalsCnt++];
                else return GetGame(difficulty + 1);
            case 3:
                if (hardsCnt < hardGames.Length) return hardGames[hardsCnt++];
                else return GetGame(difficulty + 1);
            default:
                return hardGames[0];
        }
    }
}
