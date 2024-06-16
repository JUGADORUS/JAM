using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explorer : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Repit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoTo(int index)
    {
        SceneManager.LoadScene(index);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Repit();
        }
    }
}
