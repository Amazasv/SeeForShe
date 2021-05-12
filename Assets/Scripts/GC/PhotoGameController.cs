using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class PhotoGameController : GCSequence
{
    [SerializeField]
    private Animation lipTransition = null;
    [SerializeField]
    private Sprite[] photos = null;
    [SerializeField]
    private SpriteRenderer source = null;
    [SerializeField]
    private SpriteRenderer blank = null;
    [SerializeField]
    private Image photo = null;
    [SerializeField]
    private PlayableDirector printAnim = null;
    [SerializeField]
    private GameObject button=null;

    private void Start()
    {
        CurrentStep = 0;
        lipTransition.gameObject.SetActive(false);
    }

    public void Cheese()
    {
        if (printAnim.state == PlayState.Playing) return;
        printAnim.gameObject.SetActive(true);
        photo.sprite = source.sprite;
        SetPhotoPos();
        printAnim.Play();
        CurrentStep++;
        if (CurrentStep < 3)
        {
            source.sprite = photos[CurrentStep];
        }
        else if (CurrentStep == 3)
        {
            source.gameObject.SetActive(false);
            button.SetActive(false);
            blank.gameObject.SetActive(false);
            lipTransition.gameObject.SetActive(true);
            Invoke(nameof(StartLipGame), (float)printAnim.duration);
        }
    }

    private void SetPhotoPos()
    {
        Vector2 blankViewPos = Camera.main.WorldToScreenPoint(blank.transform.position);
        Vector2 sourceViewPos = Camera.main.WorldToScreenPoint(source.transform.position);
        Vector2 offset = sourceViewPos - blankViewPos;
        float xScale= source.bounds.size.x/blank.bounds.size.x;
        float yScale = source.bounds.size.y / blank.bounds.size.y;
        photo.transform.localScale = new Vector3(xScale, yScale, 1.0f);
        //offset.Scale(new Vector2(xScale, yScale));
        photo.transform.localPosition = Vector2.zero;
        photo.transform.Translate(offset);
    }

    private void StartLipGame()
    {
        lipTransition.Play();
    }
}
