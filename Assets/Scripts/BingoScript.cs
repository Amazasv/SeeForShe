using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnOnClick))]
[RequireComponent(typeof(Image))]
public class BingoScript : MonoBehaviour
{
    [SerializeField]
    private int clueIndex = 0;
    [SerializeField]
    private int addTime = 10;

    private SpawnOnClick spawnScript = null;
    private Image image = null;
    private void Awake()
    {
        spawnScript = GetComponent<SpawnOnClick>();
        image = gameObject.GetComponent<Image>();
        UpdateVisual();
    }

    public void Bingo()
    {
        GC_5.clueCollected[clueIndex] = true;
        GameManager.Instance.time += addTime;
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        if (GC_5.clueCollected[clueIndex])
        {
            spawnScript.enabled = false;
            image.raycastTarget = false;
        }
        else
        {
            spawnScript.enabled = true;
            image.raycastTarget = true;
        }
    }
}
