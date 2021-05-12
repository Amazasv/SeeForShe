using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ins : MonoBehaviour
{
    public void InsObject(GameObject prefab)
    {
        Instantiate(prefab, transform);
    }
}
