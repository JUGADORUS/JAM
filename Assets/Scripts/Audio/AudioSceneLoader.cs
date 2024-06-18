using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSceneLoader : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            AudioManager.Instance.Music.clip = AudioManager.Instance.MenuMusic;
            AudioManager.Instance.Music.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            AudioManager.Instance.Music.clip = AudioManager.Instance.OneLevelMusic;
            AudioManager.Instance.Music.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            AudioManager.Instance.Music.clip = AudioManager.Instance.TwoLevelMusic;
            AudioManager.Instance.Music.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            AudioManager.Instance.Music.clip = AudioManager.Instance.ThreeLevelMusic;
            AudioManager.Instance.Music.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            AudioManager.Instance.Music.clip = AudioManager.Instance.FourthLevelMusic;
            AudioManager.Instance.Music.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            AudioManager.Instance.Music.clip = AudioManager.Instance.FinalLevelMusic;
            AudioManager.Instance.Music.Play();
        }
    }
}
