using System.Collections;
using TMPro;
using UnityEngine;


public class TextWriter : MonoBehaviour
{
    [SerializeField] private string _textToWrite = "";
    [SerializeField] private TextMeshProUGUI _textOnScene;

    private void Start()
    {
        StartCoroutine(WriteText());
    }

    private IEnumerator WriteText()
    {
        for(int i = 0; i < _textToWrite.Length; i++)
        {
            _textOnScene.text += _textToWrite[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
