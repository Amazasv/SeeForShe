using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class MyCamera : MonoBehaviour
{
    [SerializeField]
    private Image targetImage;
    public GameObject Print()
    {

        GameObject newPhoto=Instantiate(gameObject);
        newPhoto.GetComponent<Image>().color = Color.white;
        newPhoto.transform.localScale = new Vector3(0.6f, 0.6f);
        return newPhoto;
    }

    public void SetImage(Sprite newImage)
    {
        targetImage.sprite = newImage;
    }
}
