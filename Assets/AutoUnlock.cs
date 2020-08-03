using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpScene))]
public class AutoUnlock : MonoBehaviour
{
    [SerializeField]
    private float delay = 1.5f;
    private JumpScene jumpScene=null;
    private void Awake()
    {
        jumpScene = GetComponent<JumpScene>();
    }
    private void OnEnable()
    {
        Invoke("Unlock", delay);
    }

    public void Unlock()
    {
        jumpScene.Unlock();
    }
}
