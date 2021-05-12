using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGroup : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] p = null;


    public AudioSource player
    {
        get { return m_Player; }
        set { m_Player = value; }
    }

    [SerializeField]
    private AudioSource m_Player;
    public bool isPlaying
    {
        get {
            return m_Player.isPlaying;
        }
        private set { }
    }

    public void Play()
    {
        StartCoroutine(IPlay());
    }

    public void Stop()
    {
        m_Player.Stop();
    }


    public IEnumerator IPlay()
    {
        for(int i = 0; i < p.Length; i++)
        {
            m_Player.clip = p[i];
            m_Player.Play();
            yield return new WaitForSeconds(p[i].length);
        }
    }
}
