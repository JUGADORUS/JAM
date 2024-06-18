using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private float score = 0;
    TimeSpan timeSpan;
    private void Start()
    {
        if (score < GlobalTimer.Instance.FinalTime)
        {
            float temp = GlobalTimer.Instance.FinalTime.Value;
            timeSpan = TimeSpan.FromSeconds(temp);
            float min = timeSpan.Minutes;
            float sec = timeSpan.Seconds;
            text.SetText($"Time: {min}:{sec}");
        }
    }
}
