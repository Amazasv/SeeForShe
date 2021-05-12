using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class ObjectLevel : MonoBehaviour
{
    public AudioGroup BGM;
    public PlayableDirector inDirector;
    public PlayableDirector outDirector;
    public UnityEvent OnEnter = new UnityEvent();
    public UnityEvent OnExit = new UnityEvent();
    public void SetLevel(ObjectLevel next)
    {
        LevelManager.instance.SetLevel(next);
    }

    public void SetChapter(int index)
    {
        LevelManager.instance.SetChapter(index);
    }
}
