using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class EnemySoundMaker : MonoBehaviour
{
    [SerializeField][Range(0, 25)] private int _minTimeUntilNextPlay;
    [SerializeField][Range(0, 25)] private int _maxTimeUntilNextPlay;
    [SerializeField] private AudioClip audioClip; //AudioClip to play
    AudioSource audioSource;
    System.Random rnd;
    bool waiting = false;
    float timer;
    float timeUntilNextSound;

    private void OnValidate()
    {
        if(_minTimeUntilNextPlay > _maxTimeUntilNextPlay)
        {
            _minTimeUntilNextPlay = _maxTimeUntilNextPlay;
        }
    }
    private void Awake()
    {
        rnd = new System.Random();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    private void Update()
    {
        if (!waiting)
        {
            waiting = true;
            timeUntilNextSound = rnd.Next(_minTimeUntilNextPlay, _maxTimeUntilNextPlay);
            TimerCalculations(timeUntilNextSound);
        }
        else
        {
            TimerCalculations(timeUntilNextSound);
        }
    }
    private void TimerCalculations(float time)
    {
        if (Time.time > timer + time)
        {
            audioSource.PlayOneShot(audioClip);
            timer = Time.time;
            waiting = false;
        }
    }
}
