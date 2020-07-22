using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPage : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;

    public void Create()
    {
        if(prefab && GC_5.Instance)
        {
            GC_5.Instance.CreateNewPage(prefab);
        }
    }
}
