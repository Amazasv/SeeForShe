using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageOnEnable : MonoBehaviour
{
    [SerializeField]
    private string MethodName = "";

    private void OnEnable()
    {
        SendMessageUpwards(MethodName);
    }

}
