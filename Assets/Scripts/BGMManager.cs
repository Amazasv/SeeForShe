using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance = null;

    [SerializeField]
    private float m_transition_duration;

    public AudioGroup current
    {
        get { return m_Current; }
        set
        {
            if (m_Current != value)
                PlayBGM(value);
            else
                Replay();
        }
    }
    [SerializeField]
    private AudioGroup m_Current = null;


    [SerializeField]
    private AudioClip m_TransitionMusic = null;

    [SerializeField]
    private AudioSource player1 = null;
    [SerializeField]
    private AudioSource player2 = null;
    private void PlayBGM(AudioGroup next)
    {
        if (next == null) return;
        StopAllCoroutines();
        StartCoroutine(INextSong(next));
        m_Current = next;
    }

    private void Replay() { }

    IEnumerator INextSong(AudioGroup next)
    {
        float t = 0;
        if (m_TransitionMusic && m_Current)
        {
            player2.clip = m_TransitionMusic;
            player2.Play();
            while (t < m_transition_duration / 2)
            {
                player1.volume = 1 - t / (m_transition_duration / 2);
                player2.volume = t / (m_transition_duration / 2);
                t += Time.deltaTime;
                yield return null;
            }
            t = 0;
            next.player = player1;
            next.Play();
            while (t < m_transition_duration)
            {
                player1.volume = t / (m_transition_duration / 2);
                player2.volume = 1 - t / (m_transition_duration / 2);
                t += Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            next.player = player1;
            next.Play();
        }
    }



    private void Awake()
    {
        instance = this;
        player1.playOnAwake = player2.playOnAwake = false;
        player1.loop = true;
        player2.loop = false;
        m_transition_duration = m_TransitionMusic.length;
    }

}
