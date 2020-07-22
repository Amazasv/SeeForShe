using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnOnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject prefab = null;
    [SerializeField]
    private Transform parent = null;

    static private GameObject lastObject = null;

    private void Clear()
    {
        if (lastObject) Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clear();
        lastObject = Instantiate(prefab, eventData.position, Quaternion.identity, parent);
    }
}
