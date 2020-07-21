using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayClue : MonoBehaviour
{
    [SerializeField]
    private bool[] clues = null;
    private void Update()
    {
        clues = GC_5.clueCollected;
    }
}
