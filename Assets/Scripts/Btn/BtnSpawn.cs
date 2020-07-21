using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;
    private void Awake()
    {
        if(prefab) GetComponent<Button>().onClick.AddListener( delegate { gameObject.SendMessageUpwards("InstantiateNew", prefab); });
    }
}
