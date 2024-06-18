using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class TextUp : MonoBehaviour
{
    public Explorer explorer;
    public float timer;
    public float timerClose;
    public float liftSpeed;

    private void Update()
    {
        timer -= Time.deltaTime;
        timerClose += Time.deltaTime;
        if(timer <= 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.y += liftSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
        if(timerClose >= 80f) 
        {
            explorer.GoTo(0);
        }
    }
}
