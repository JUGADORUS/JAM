using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private string _textToWrite = "";
    [SerializeField] private TextMeshProUGUI _text;

    private TimeSpan _timeSpan;
    private int _minutes = 0;
    private int _seconds = 0;

    public IEnumerator WriteText()
    {
        for (int i = 0; i < _textToWrite.Length; i++)
        {
            _text.text += _textToWrite[i];
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SetTimerInGame()
    {
        CountTime(ref _minutes,ref _seconds, GlobalTimer.Instance.glTimer);
        _text.SetText($"{_minutes}:{_seconds}");
    }

    public void SetTimerInMenu()
    {
        float _score = 0;

        if (_score < GlobalTimer.Instance.FinalTime)
        {
            CountTime(ref _minutes, ref _seconds, GlobalTimer.Instance.FinalTime.Value);
            _text.SetText($"Time: {_minutes}:{_seconds}");
        }
    }

    private void CountTime(ref int minutes, ref int seconds, float temp)
    {
        _timeSpan = TimeSpan.FromSeconds(temp);

        minutes = _timeSpan.Minutes;
        seconds = _timeSpan.Seconds;
    }
}
