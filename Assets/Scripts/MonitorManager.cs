using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonitorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] btns = null;
    [SerializeField]
    private int[] timeLimit = new int[] { 16 * 60 + 30, 17 * 60 + 0, 17 * 60 + 30, 18 * 60 + 0, 18 * 60 + 30 };
    private void OnEnable()
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].SetActive(GameManager.Instance.time >= timeLimit[i]);
        }
        btns[1].SetActive(GameManager.Instance.flag_catch || GameManager.Instance.flag_get_help);
        btns[2].SetActive(GameManager.Instance.flag_gentle_speaking);
    }
}
