using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class GC_7_1 : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director = null;
    public void StartTL()
    {
        director.Play();
    }

}
