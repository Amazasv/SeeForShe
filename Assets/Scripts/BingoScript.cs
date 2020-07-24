using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BingoScript : MonoBehaviour
{
    [SerializeField]
    private int clueIndex = 0;

    //private AddTimeScript script = null;

    public UnityEvent OnConfirm;

    private void Awake()
    {
        //script = GetComponent<AddTimeScript>();
    }
    public void Bingo()
    {
        GC_5.Instance.SetFlag(clueIndex, true);
        OnConfirm.Invoke();
        //GetComponentInParent<MonitorPageManager>().EnableClue();
        //if (script) script.AddTime();
    }
}
