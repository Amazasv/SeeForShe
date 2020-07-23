using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AddTimeScript))]
public class BingoScript : MonoBehaviour
{
    [SerializeField]
    private int clueIndex = 0;

    private AddTimeScript script=null;
    private void Awake()
    {
        script = GetComponent<AddTimeScript>();
    }
    public void Bingo()
    {
        GC_5.Instance.SetFlag(clueIndex,true);
        GetComponentInParent<MonitorPageManager>().EnableClue();
        script.AddTime();
    }
}
