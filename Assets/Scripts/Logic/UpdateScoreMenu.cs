using System;
using TMPro;
using UnityEngine;

public class UpdateScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private float _score = 0;
    private TimeSpan _timeSpan;
    private void Start()
    {
        if (_score < GlobalTimer.Instance.FinalTime)
        {
            float temp = GlobalTimer.Instance.FinalTime.Value;
            _timeSpan = TimeSpan.FromSeconds(temp);

            float min = _timeSpan.Minutes;
            float sec = _timeSpan.Seconds;
            text.SetText($"Time: {min}:{sec}");
        }
    }
}
