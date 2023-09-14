using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private float Volume;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Volume = _volumeSlider.value;
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volumeValue)
    {
        Volume = volumeValue;
    }
}
