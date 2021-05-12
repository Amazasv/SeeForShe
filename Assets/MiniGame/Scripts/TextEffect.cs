using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextEffect : MonoBehaviour
{
    private Text thisText;
    [SerializeField]
    private float gap = 0.1f;
    [SerializeField]
    private float delay = 2.0f;

    public float PutText(string content)
    {
        thisText = GetComponentInChildren<Text>();
        thisText.text = "";
        StopAllCoroutines();
        StartCoroutine(IEPutText(content));
        return content.Length * gap;
    }

    IEnumerator IEPutText(string content)
    {
        StringBuilder s = new StringBuilder(content.Length);
        for (int i = 0; i < content.Length; i++)
        {
            s.Append(content[i]);
            thisText.text = s.ToString();
            yield return new WaitForSeconds(gap);
        }
        yield return new WaitForSeconds(delay);
        thisText.text = "";
    }
}
