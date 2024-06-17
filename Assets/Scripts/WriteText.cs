using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WriteText : MonoBehaviour
{
    [SerializeField] string text = "";
    [SerializeField] TextMeshProUGUI textScene;

    private void Start()
    {
        StartCoroutine(writeText());
    }
    private IEnumerator writeText()
    {
        for(int i = 0; i < text.Length; i++)
        {
            textScene.text += text[i];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
