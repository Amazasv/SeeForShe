using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnNoDualClick : MonoBehaviour
{
    [SerializeField]
    private float gap = 0.5f;
    private Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Lock);
    }
    private void OnEnable()
    {
        Unlock();
    }

    private void Lock()
    {
        btn.interactable = false;
        Invoke("Unlock", gap);
    }
    private void Unlock()
    {
        btn.interactable = true;
    }
}
