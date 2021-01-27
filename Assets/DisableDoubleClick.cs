using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class DisableDoubleClick : MonoBehaviour
{
    [SerializeField]
    private float gap = 0.3f;

    private Button btn;
    private float t = 0.0f;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { t = gap; });
    }

    private void Update()
    {
        btn.interactable = (t <= 0.0f);
        t -= Time.deltaTime;
    }

}
