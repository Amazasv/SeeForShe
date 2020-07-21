using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNewAsChild : MonoBehaviour
{
    private float lastTime = 0;
    public void InstantiateNew(GameObject prefab)
    {
        if (Time.time - lastTime > 0.5f)
        {
            Instantiate(prefab, transform);
            lastTime = Time.time;
        }
    }
}
