using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnOnClick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField]
    public GameObject prefab = null;

    static private List<GameObject> prefabs = new List<GameObject>();

    private void Clear()
    {
        foreach (GameObject gameObject in prefabs) Destroy(gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (prefab)
        {
            Clear();
            prefabs.Add(Instantiate(prefab, eventData.position, Quaternion.identity, transform));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        return;
    }
}
