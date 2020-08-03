using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BingoScript : MonoBehaviour
{
    [SerializeField]
    private int clueIndex = 0;

    public UnityEvent OnConfirm;

    public void Bingo()
    {
        GC_5.Instance.SetFlag(clueIndex, true);
        OnConfirm.Invoke();
    }
}
