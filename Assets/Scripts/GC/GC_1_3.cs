using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GC_1_3 : MonoBehaviour
{
    [SerializeField]
    private ObjectLevel nextScene = null;
    [SerializeField]
    private SpriteRenderer targetSprite=null;
    [SerializeField]
    private Sprite[] sprites=null;
    [SerializeField]
    private List<Draggable> items = new List<Draggable>();
    [SerializeField]
    private List<GameObject> emptyHanger = new List<GameObject>();

    private int currentStep = 0;

    private void OnEnable()
    {
        UpdateVisual();
    }

    public void DressUp(int index)
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        curPosition.Set(curPosition.x, curPosition.y, 0.0f);
        if (GetComponent<BoxCollider2D>().bounds.Contains(curPosition))
            if (index == currentStep)
            {
                currentStep++;
                UpdateVisual();
                if (currentStep == items.Count)
                {
                    LevelManager.instance.SetLevel(nextScene);
                }
            }
    }

    public void DropCheck(Draggable item)
    {
        if (items.IndexOf(item) == currentStep)
        {
            DressUp(0);
        }
    }

    private void UpdateVisual()
    {
        for (int i = 0; i < items.Count; i++) items[i].gameObject.SetActive(i >= currentStep);
        for (int i = 0; i < emptyHanger.Count; i++) emptyHanger[i].SetActive(i < currentStep);
        targetSprite.sprite = sprites[currentStep];
    }
}
