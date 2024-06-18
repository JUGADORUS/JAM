using System;
using TMPro;
using UnityEngine;

public class UpdateGlobalTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTimer;

    private TimeSpan _timeSpan;
    private float _temp;
    public int min = 0;
    public float sec;

    private void FixedUpdate()
    {
        _temp = GlobalTimer.Instance.glTimer;
        _timeSpan = TimeSpan.FromSeconds(_temp);

        min = _timeSpan.Minutes;
        sec = _timeSpan.Seconds;
        textTimer.SetText($"{min}:{sec}");
    }
}
