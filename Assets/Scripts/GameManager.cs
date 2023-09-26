using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class GameManager : MonoBehaviour
{
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }
    public Sound[] sounds;

    [SerializeField] private Slider _volumeSlider;

    private void Awake()
    {
        // Singelton check
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            //Init all the Audio sources with the setting from the editor
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    private void Start()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
        AudioPlayer("Theme");
    }

    public void ChangeVolume(float volumeValue)
    {
        Debug.Log(volumeValue);
        Sound s = Array.Find(sounds, sound => sound.name == "Theme");
        s.source.volume = volumeValue;
    }

    public void AudioPlayer(string name)
    {
        // ENCAPSULATION & ABSTRACTION
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        s.source.Play();
    }
}
