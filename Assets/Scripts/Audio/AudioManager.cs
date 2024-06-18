using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [field: SerializeField] public AudioSource Music { get; private set; }
    [field: SerializeField] public AudioSource Sound { get; private set; }
    public AudioClip JumpClip;
    public AudioClip DeathClip;
    public AudioClip SpawnClip;
    public AudioClip TakeCoffeClip;
    public AudioClip MenuMusic;
    public AudioClip OneLevelMusic;
    public AudioClip TwoLevelMusic;
    public AudioClip ThreeLevelMusic;
    public AudioClip FourthLevelMusic;
    public AudioClip FinalLevelMusic;
    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        if (!Instance)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }


    private void Start()
    {
        float musicvalue = AudioManager.Instance.Music.volume;
        if (PlayerPrefs.HasKey("Music"))
        {
            musicvalue = PlayerPrefs.GetFloat("Music");
        }
        PlayerPrefs.SetFloat("Music", musicvalue);
        AudioManager.Instance.Music.volume = musicvalue;

        float soundvalue = AudioManager.Instance.Sound.volume;
        if (PlayerPrefs.HasKey("Sound"))
        {
            soundvalue = PlayerPrefs.GetFloat("Sound");
        }
        PlayerPrefs.SetFloat("Sound", musicvalue);
        AudioManager.Instance.Sound.volume = musicvalue;
    }
}
