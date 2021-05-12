using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MiniGameEnd : MonoBehaviour
{
    [SerializeField]
    private string s1 = "", s2 = "";
    [SerializeField]
    private TextEffect t1 = null, t2 = null;

    public UnityEvent OnStop = new UnityEvent();
    private void OnEnable()
    {
        StartCoroutine(EndAnim());
    }

    IEnumerator EndAnim()
    {
        if (t1)
        {
            t1.PutText(s1);
            yield return new WaitForSeconds(2f);
        }
        if (t2)
        {
            t2.PutText(s2);
            yield return new WaitForSeconds(2f * 2);
        }
        OnStop.Invoke();
    }
}
