using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class ClickChangeSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites=null;

    public UnityEvent onLastClick = new UnityEvent();
    private Image image;

    private int count;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        count = 1;
    }

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(ChangeSprite);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(ChangeSprite);
    }

    private void ChangeSprite()
    {
        if (count < sprites.Length)
        {
            image.sprite = sprites[count++];
        }
        else
        {
            onLastClick.Invoke();
        }
    }
}
