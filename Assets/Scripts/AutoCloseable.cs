using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCloseable : MonoBehaviour
{
    public void close()
    {
        Destroy(gameObject);
    }
}
