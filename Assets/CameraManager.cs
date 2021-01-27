using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraManager : MonoBehaviour
{


    private Dictionary<string, PlayableBinding> bindingDict = new Dictionary<string, PlayableBinding>();
    //给字典中添加键和值
    //由于SetGenericBinding第一个参数为Object因此不能直接用string需要利用字典
    public PlayableDirector director = null;
    private GameObject newPhoto = null;


    private void Awake()
    {
        director = GetComponentInChildren<PlayableDirector>();
        director.stopped += Director_stopped;
        GetBindingDict();
    }

    private void Director_stopped(PlayableDirector obj)
    {
        gameObject.SetActive(false);
        if (newPhoto) Destroy(newPhoto);
    }

    public void Print(GameObject photo){
        photo.transform.SetParent(transform);
        director.SetGenericBinding(bindingDict["Animation Track (2)"].sourceObject, photo);
        newPhoto = photo;
        director.Play();
    }

    private void GetBindingDict()
    {
        foreach (PlayableBinding pb in director.playableAsset.outputs)
        {
            if (!bindingDict.ContainsKey(pb.streamName))
            {
                bindingDict.Add(pb.streamName, pb);
            }
        }
    }
}
