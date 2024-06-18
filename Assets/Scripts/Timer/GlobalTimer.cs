using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalTimer : MonoBehaviour
{
    public float glTimer;
    public float? FinalTime = null;
    public static GlobalTimer Instance { get; private set; }
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

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex < 3)
        {
            return;
        }
        glTimer += Time.deltaTime;
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (FinalTime == null)
            {
                FinalTime = glTimer;
            }
        }
    }

}
