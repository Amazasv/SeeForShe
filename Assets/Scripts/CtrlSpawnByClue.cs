using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnOnClick))]
[RequireComponent(typeof(Image))]
public class CtrlSpawnByClue : MonoBehaviour
{
    [SerializeField]
    private bool greater = true;
    [SerializeField]
    private int clueIndex = 0;
    [SerializeField]
    private int optional = 0;


    private SpawnOnClick spawnScript = null;
    private Image image = null;
    private void Awake()
    {
        spawnScript = GetComponent<SpawnOnClick>();
        image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        spawnScript.enabled = false;
        image.raycastTarget = false;
        if (GC_5.clueCollected[clueIndex] || GC_5.clueCollected[optional])
        {
            if (greater && GameManager.Instance.time >= 19 * 60 + 30)
            {
                spawnScript.enabled = true;
                image.raycastTarget = true;
            }
            if (!greater && GameManager.Instance.time <= 19 * 60 + 30)
            {
                spawnScript.enabled = true;
                image.raycastTarget = true;
            }
        }
    }
}
