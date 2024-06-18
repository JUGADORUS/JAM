using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider audio;
    [SerializeField] private Slider volume;

    private void OnEnable()
    {
        volume.value = AudioManager.Instance.Sound.volume;
        volume.onValueChanged.AddListener(SettingsVolume);
        audio.value = AudioManager.Instance.Music.volume;
        audio.onValueChanged.AddListener(SettingsMusic);
    }
    private void OnDisable()
    {
        volume.onValueChanged.RemoveListener(SettingsVolume);
        audio.onValueChanged.RemoveListener(SettingsMusic);
    }
    private void SettingsMusic(float value)
    {
        AudioManager.Instance.Music.volume = value;
        PlayerPrefs.SetFloat("Music", value);
    }
    private void SettingsVolume(float value)
    {
        AudioManager.Instance.Sound.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }
}
