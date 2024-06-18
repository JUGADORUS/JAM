using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateGlobalTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTimer;
    TimeSpan timeSpan;
    private float temp;
    public int min = 0;
    public float sec;


    private void FixedUpdate()
    {
        temp = GlobalTimer.Instance.glTimer;
        timeSpan = TimeSpan.FromSeconds(temp);
        min = timeSpan.Minutes;
        sec = timeSpan.Seconds;
        textTimer.SetText($"{min}:{sec}");
    }
}
