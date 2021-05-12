using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class FoodApp : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director=null;
    [SerializeField]
    private ClickChangeSprite[] foods = new ClickChangeSprite[3];

    private void Start()
    {
        foreach (var f in foods)
        {
            f.enabled = false;
        }
    }

    public void StartEating()
    {
        foreach(var f in foods)
        {
            f.enabled = true;
        }
        director.Play();
    }
   
}
