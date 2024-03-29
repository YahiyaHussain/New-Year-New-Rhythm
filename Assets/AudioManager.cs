﻿using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake() {
        
        if (Instance == null) { Instance = this; } else { Debug.Log("error too many " + name); }
        
        // Background music doesnt change/stop when switching from start menu to game
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

        // copies mp3 attributes into audio manager
        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        foreach(AudioSource s in GetComponents<AudioSource>())
        {
            s.volume = levelSelectionTracker.Instance.volumeLevel;
        }
    }
    // plays audio file
    public void Play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }
    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Pause();
    }
    public bool isPlaying (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return false;
        }
        return s.source.isPlaying;
    }
    public void click()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "click");
        if (s == null)
        {
            Debug.LogWarning("Sound: " + "click" + " not found");
            return;
        }
        s.source.Play();
    }
    public void adjustvolume(float volume)
    {
        foreach (AudioSource s in GetComponents<AudioSource>())
        {
            s.volume = volume;
        }
    }
    public void volumeslider()
    {
        float volume = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>().value;
        adjustvolume(volume);
        levelSelectionTracker.Instance.volumeLevel = volume;
    }
}
