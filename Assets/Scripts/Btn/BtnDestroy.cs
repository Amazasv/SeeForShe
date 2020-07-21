using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;
    private void Awake()
    {
        if (target) GetComponent<Button>().onClick.AddListener(delegate { Destroy(target); });
    }

}
